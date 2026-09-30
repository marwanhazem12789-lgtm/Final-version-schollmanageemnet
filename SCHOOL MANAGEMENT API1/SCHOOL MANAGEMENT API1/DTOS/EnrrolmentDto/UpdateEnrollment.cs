using SCHOOL_MANAGEMENT_API1.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SCHOOL_MANAGEMENT_API1.DTOS.EnrrolmentDto
{
    public class UpdateEnrollment
    {
        [Required, DataType(DataType.DateTime)]
        public DateTime EnrollmentDate { get; set; }
        [Required, Range(0, 100)]
        public int Grade { get; set; }
        [ForeignKey(nameof(Student))]
        public int StudentId { get; set; }
        [ForeignKey(nameof(Subject))]

        public int SubjectId { get; set; }
    }
}
