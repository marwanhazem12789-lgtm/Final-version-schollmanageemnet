using SCHOOL_MANAGEMENT_API1.Genarics;
using SCHOOL_MANAGEMENT_API1.Models;

namespace SCHOOL_MANAGEMENT_API1.AllCustoms.EnrollmentCustoms
{
    public interface IEnrollment : IGenaricRepo<Enrollment>
    {
        Enrollment GetOldestEnrollmentBySubject(int subjectId);
        List<int> GetStudentIdsEnrolledInBothSubjects(int subjectId1, int subjectId2);
    }
}
