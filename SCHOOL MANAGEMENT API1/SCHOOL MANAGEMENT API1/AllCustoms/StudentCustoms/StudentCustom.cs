using Microsoft.EntityFrameworkCore;
using SCHOOL_MANAGEMENT_API1.Genarics;
using SCHOOL_MANAGEMENT_API1.Models;

namespace SCHOOL_MANAGEMENT_API1.AllCustoms.StudentCustoms
{
    public class StudentCustom  : GenaricRepo<Student>, IStudent
    {
        private readonly Context c;

        public StudentCustom(Context context) : base(context)
        {
            c = context;
        }

        public Student GetStudentFirstByClassRoomId(int classroomId)
        {
            return c.Students
                .Include(s => s.ClassRoom)
                .FirstOrDefault(s => s.ClassRoom.Id == classroomId);
        }

        public Student GetStudentSingle(string email)
        {
            return c.Students
                .Include(s => s.ClassRoom)
                .SingleOrDefault(s => s.Email == email);
        }


    }
}
