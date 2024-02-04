using Microsoft.EntityFrameworkCore;
using StudentRecords.Models;
using System.Collections.Generic;

namespace StudentRecords.DBContext
{
    public class StudentRecordsContext:DbContext
    {
        public StudentRecordsContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<StudentDetails> StudentDetailss { get; set; }
        public DbSet<Exams> Examss { get; set; }
        public DbSet<StudentMarks> StudentsMarks { get; set; }
    }
}
