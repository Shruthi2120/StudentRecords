using System.ComponentModel.DataAnnotations;

namespace StudentRecords.Models
{
    public class StudentDetails
    {
        [Key]
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public string FullName { get; set; }
        public string Class { get; set; }
        public string Section { get; set; }
        public string ClassGrade { get; set; }
        public string SectionGrade { get; set; }
    }
}
