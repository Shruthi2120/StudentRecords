using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentRecords.Interfaces;
using StudentRecords.Models;
using StudentRecords.Services;

namespace StudentRecords.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentRecordsController : ControllerBase
    {
        private readonly IStudentRecords _studentRecords;
        public StudentRecordsController(IStudentRecords studentRecords)
        {
            _studentRecords = studentRecords;
        }

        [HttpGet("{studentId}")]
        public IActionResult Get(int studentId)
        {
            var studentDetails = _studentRecords.Get(studentId);

            if (studentDetails != null)
            {
                return Ok(studentDetails);
            }

            return NotFound($"No data found for studentId {studentId}");
        }


        [HttpPut("update/{studentId}")]
        public IActionResult UpdateStudentDetails(int studentId, [FromBody] UpdateStudentMarksDTO updateStudentMarksDTO)
        {
            try
            {
                var result = _studentRecords.UpdateStudentDetailsByMarks(studentId, updateStudentMarksDTO.UpdatedStudentMarks);

                if (result == null)
                {
                    return NotFound($"Student with ID {studentId} not found.");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to update student details: {ex.Message}");
            }
        }

    }
}
