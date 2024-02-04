using StudentRecords.Models;

namespace StudentRecords.Interfaces
{
    public interface IStudentRecords
    {
        StudentDetails Get(int studentId);

        StudentDetails UpdateStudentDetailsByMarks(int studentId, List<UpdatedStudentMark> updatedStudentMarks);
    }
}
