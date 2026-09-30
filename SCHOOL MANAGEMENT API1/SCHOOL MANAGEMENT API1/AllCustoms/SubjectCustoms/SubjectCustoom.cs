using Microsoft.EntityFrameworkCore;
using SCHOOL_MANAGEMENT_API1.Genarics;
using SCHOOL_MANAGEMENT_API1.Models;

namespace SCHOOL_MANAGEMENT_API1.AllCustoms.SubjectCustoms
{
    public class SubjectCustoom : GenaricRepo<Subject>, ISubject
    {
        private readonly Context _context;
        public SubjectCustoom(Context c) : base(c)
        {
            _context = c;

        }
        public Subject GetFirstSubjectByTeacher(int teacherId)
        {
            return _context.Subjects
                .Where(s => s.TeacherId == teacherId)
                .OrderBy(s => s.Name)
                .FirstOrDefault();
        }

        public Subject GetLastSubjectByTeacher(int teacherId)
        {
            return _context.Subjects
                .Where(s => s.TeacherId == teacherId)
                .OrderByDescending(s => s.Id)
                .FirstOrDefault();
        }

        public bool CheckSubjectIdExistsInList(int subjectId, List<int> subjectIds)
        {
            return subjectIds != null && subjectIds.Contains(subjectId);
        }

        public dynamic GetBasicInfoByTeacher(int teacherId)
        {
            return _context.Subjects
                .Where(s => s.TeacherId == teacherId)
                .Select(s => new { s.Id, s.Name, s.MaxGrade })
                .ToList();
        }

        public List<Subject> GetSubjectsOrderedByMaxGradeDesc()
        {
            return _context.Subjects
                .OrderByDescending(s => s.MaxGrade)
                .ToList();
        }

        public List<Subject> GetSubjectsOrderedByTeacherAndGrade()
        {
            return _context.Subjects
                .OrderBy(s => s.TeacherId)
                .ThenByDescending(s => s.MaxGrade)
                .ToList();
        }

        public int GetSubjectCountByTeacher(int teacherId)
        {
            return _context.Subjects
                .Count(s => s.TeacherId == teacherId);
        }

        public List<Subject> GetSubjectsByTeacherToList(int teacherId)
        {
            return _context.Subjects
                .Where(s => s.TeacherId == teacherId)
                .ToList();
        }

        public dynamic GetSubjectsWithTeacherInfo(int teacherId)
        {
            return _context.Subjects
                .Where(s => s.TeacherId == teacherId)
                .Join(_context.Teachers,
                    s => s.TeacherId,
                    t => t.Id,
                    (s, t) => new { SubjectName = s.Name, TeacherFullName = t.FirstName + " " + t.LastName })
                .ToList();
        }

        public List<Subject> TakeSubjects(int count)
        {
            return _context.Subjects
                .OrderBy(s => s.Id)
                .Take(count).ToList();
        } 
    }
}
