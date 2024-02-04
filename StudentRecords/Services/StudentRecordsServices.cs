using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using StudentRecords.DBContext;
using StudentRecords.Interfaces;
using StudentRecords.Models;

namespace StudentRecords.Services
{
    public class StudentRecordsServices : IStudentRecords
    {
        private readonly StudentRecordsContext _studentRecordsContext;
        public StudentRecordsServices(StudentRecordsContext studentRecordsContext)
        {
            _studentRecordsContext = studentRecordsContext;
        }
        public StudentDetails UpdateStudentDetailsByMarks(int studentId, List<UpdatedStudentMark> updatedStudentMarks)
        {
            var studentDetails = _studentRecordsContext.StudentDetailss.FirstOrDefault(s => s.StudentId == studentId);

            if (studentDetails == null)
            {
                return null;
            }

            foreach (var updatedMark in updatedStudentMarks)
            {
                UpdateStudentMarks(studentId, updatedMark);
            }
            _studentRecordsContext.SaveChanges();

            UpdateGrades(studentId, updatedStudentMarks.FirstOrDefault()?.ExamId);

            _studentRecordsContext.SaveChanges();

            return studentDetails;
        }

        private void UpdateStudentMarks(int studentId, UpdatedStudentMark updatedStudentMark)
        {
            var existingMark = _studentRecordsContext.StudentsMarks
                .FirstOrDefault(m => m.StudentId == studentId && m.ExamId == updatedStudentMark.ExamId);

            if (existingMark != null)
            {
                existingMark.Science = updatedStudentMark.Science;
                existingMark.Maths = updatedStudentMark.Maths;
                existingMark.English = updatedStudentMark.English;
                existingMark.Total = updatedStudentMark.Science + updatedStudentMark.Maths + updatedStudentMark.English;
            }
            else
            {
                var newMark = new StudentMarks
                {
                    StudentId = studentId,
                    ExamId = updatedStudentMark.ExamId,
                    Science = updatedStudentMark.Science,
                    Maths = updatedStudentMark.Maths,
                    English = updatedStudentMark.English,
                    Total = updatedStudentMark.Science + updatedStudentMark.Maths + updatedStudentMark.English
                };

                _studentRecordsContext.StudentsMarks.Add(newMark);
            }
        }
        private void UpdateGrades(int studentId, int? examId)
        {
            var studentMarksList = _studentRecordsContext.StudentsMarks
                .Where(s => s.StudentId == studentId)
                .ToList();

            if (studentMarksList.Any())
            {
                var sortedStudents = studentMarksList.OrderByDescending(s => s.Total).ToList();

                var sectionGrade = sortedStudents.FindIndex(s => s.StudentId == studentId) + 1;
                var studentDetails = _studentRecordsContext.StudentDetailss.FirstOrDefault(s => s.StudentId == studentId);

                if (studentDetails != null)
                {
                    studentDetails.SectionGrade = sectionGrade.ToString();

                    var classTotalMarks = _studentRecordsContext.StudentsMarks
                        .Where(s => s.StudentDetails.Class == studentDetails.Class)
                        .Sum(s => s.Total);

                    var classGrade = sortedStudents.FindIndex(s => s.StudentId == studentId) + 1;
                    studentDetails.ClassGrade = classGrade.ToString();
                }
            }
        }

        public StudentDetails Get(int studentId)
        {
            var studentDetails = _studentRecordsContext.StudentDetailss.FirstOrDefault(s => s.StudentId == studentId);

            if (studentDetails != null)
            {
                return studentDetails;
            }

            return null;
        }
    }
}




       

   


    

        
