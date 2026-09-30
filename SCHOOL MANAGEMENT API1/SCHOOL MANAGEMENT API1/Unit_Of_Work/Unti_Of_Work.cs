using SCHOOL_MANAGEMENT_API1.AllCustoms.ClassRoomCustoms;
using SCHOOL_MANAGEMENT_API1.AllCustoms.DepartmentCustoms;
using SCHOOL_MANAGEMENT_API1.AllCustoms.EnrollmentCustoms;
using SCHOOL_MANAGEMENT_API1.AllCustoms.StudentCustoms;
using SCHOOL_MANAGEMENT_API1.AllCustoms.SubjectCustoms;
using SCHOOL_MANAGEMENT_API1.AllCustoms.TeacherCustoms;
using SCHOOL_MANAGEMENT_API1.Models;

namespace SCHOOL_MANAGEMENT_API1.Unit_Of_Work
{
    public class Unti_Of_Work : IUnitOfWork
    {
        private readonly Context c;

        public IClassroom classrooms { get; }

        public IStudent Students { get; }

        public ISubject Subjects { get; }

        public IEnrollment Enrollments { get; }

        public IDepartment Departments { get; }

        public ITeacer Teachers { get; }

        public Unti_Of_Work(ISubject s , IStudent st , IDepartment d , IEnrollment e , ITeacer t , IClassroom cl , Context c)
        {
            Students = st;
            classrooms = cl;
            Subjects = s; Enrollments = e;
            this.c = c;
            Departments = d;
            Teachers = t;
        }

        public int Save()
        {
            return c.SaveChanges();
        }

    }
}
