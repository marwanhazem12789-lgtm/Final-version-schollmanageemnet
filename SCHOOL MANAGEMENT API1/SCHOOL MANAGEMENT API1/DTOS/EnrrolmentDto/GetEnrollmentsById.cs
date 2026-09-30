using System.ComponentModel.DataAnnotations;

namespace SCHOOL_MANAGEMENT_API1.DTOS.EnrrolmentDto
{
    public class GetEnrollmentsById
    {
        [Key]
        public int Id { get; set; }
        [Required, DataType(DataType.DateTime)]
        public DateTime EnrollmentDate { get; set; }
        [Required, Range(0, 100)]
        public int Grade { get; set; }
        [Required, MaxLength(100)]

        public string StudentName { get; set; }
        [Required, MaxLength(100)]
        public string SubjectName { get; set; }
    }
}
