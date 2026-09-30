using System.ComponentModel.DataAnnotations;

namespace SCHOOL_MANAGEMENT_API1.DTOS.ClassRoomDto
{
    public class GetClassRoomsById
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        [Required, Range(1, 100)]
        public int Capacity { get; set; }
        [Required, Range(1, 12)]
        public int GradeLevel { get; set; }
<<<<<<< HEAD
=======

>>>>>>> 2cc9e5f736dec4ba8beec69e6337d6fe8dc7c472
    }
}
