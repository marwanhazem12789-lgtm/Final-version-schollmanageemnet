using SCHOOL_MANAGEMENT_API1.Genarics;
using SCHOOL_MANAGEMENT_API1.Models;

namespace SCHOOL_MANAGEMENT_API1.AllCustoms.EnrollmentCustoms
{
    public class EnrollmentCustom : GenaricRepo<Enrollment>, IEnrollment
    {
        private readonly Context c;

        public EnrollmentCustom(Context context) : base(context)
        {
            c = context;
        }

        public Enrollment GetOldestEnrollmentBySubject(int subjectId)
        {
            return c.Enrollments
                .Where(e => e.SubjectId == subjectId)
                .OrderBy(e => e.EnrollmentDate)
                .FirstOrDefault();
        }

        public List<int> GetStudentIdsEnrolledInBothSubjects(int subjectId1, int subjectId2)
        {
            var studentsSub1 = c.Enrollments
                .Where(e => e.SubjectId == subjectId1)
                .Select(e => e.StudentId);

            var studentsSub2 = c.Enrollments
                .Where(e => e.SubjectId == subjectId2)
                .Select(e => e.StudentId);

            return studentsSub1.Intersect(studentsSub2).ToList();
        }
    }
}
