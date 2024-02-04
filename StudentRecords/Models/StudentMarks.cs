using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentRecords.Models
{
    public class StudentMarks
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("StudentDetails")]
        public int StudentId { get; set; }

        [ForeignKey("Exams")]
        public int ExamId { get; set; }
        public int Science { get; set; }
        public int Maths { get; set; }
        public int English { get; set; }
        public int Total { get; set; }
        public StudentDetails StudentDetails { get; set; }
        public Exams Exams { get; set; }
    }
}
