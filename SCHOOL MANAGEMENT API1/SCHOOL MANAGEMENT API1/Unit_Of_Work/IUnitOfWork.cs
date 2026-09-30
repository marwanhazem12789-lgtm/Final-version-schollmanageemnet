using SCHOOL_MANAGEMENT_API1.AllCustoms.ClassRoomCustoms;
using SCHOOL_MANAGEMENT_API1.AllCustoms.DepartmentCustoms;
using SCHOOL_MANAGEMENT_API1.AllCustoms.EnrollmentCustoms;
using SCHOOL_MANAGEMENT_API1.AllCustoms.StudentCustoms;
using SCHOOL_MANAGEMENT_API1.AllCustoms.SubjectCustoms;
using SCHOOL_MANAGEMENT_API1.AllCustoms.TeacherCustoms;

namespace SCHOOL_MANAGEMENT_API1.Unit_Of_Work
{
    public interface IUnitOfWork
    {
        IClassroom classrooms { get; }
        IStudent Students { get; }
        ISubject Subjects { get; }
        IEnrollment Enrollments { get; }
        IDepartment Departments { get; }
        ITeacer Teachers { get; }
        int Save();

    }
}
