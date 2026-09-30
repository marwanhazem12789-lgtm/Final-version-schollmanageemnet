using SCHOOL_MANAGEMENT_API1.Genarics;
using SCHOOL_MANAGEMENT_API1.Models;

namespace SCHOOL_MANAGEMENT_API1.AllCustoms.StudentCustoms
{
    public interface IStudent : IGenaricRepo<Student>
    {
        Student GetStudentFirstByClassRoomId(int classroomId);
        Student GetStudentSingle(string email);
    }
}
