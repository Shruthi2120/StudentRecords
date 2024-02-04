using System.ComponentModel.DataAnnotations;

namespace StudentRecords.Models
{
    public class Exams
    {
        [Key]
        public int ExamId { get; set; }
        public string ExamName { get; set; }
        public string Class { get; set; }
    }
}
