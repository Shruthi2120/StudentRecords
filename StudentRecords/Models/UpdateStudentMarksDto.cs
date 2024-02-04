namespace StudentRecords.Models
{
    public class UpdateStudentMarksDTO
    {
        public List<UpdatedStudentMark> UpdatedStudentMarks { get; set; }
    }

    public class UpdatedStudentMark
    {
        public int ExamId { get; set; }
        public int Science { get; set; }
        public int Maths { get; set; }
        public int English { get; set; }
        public int Total { get; set; }
    }

}
