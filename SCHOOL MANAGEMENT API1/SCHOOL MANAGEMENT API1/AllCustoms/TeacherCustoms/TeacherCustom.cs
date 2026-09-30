using SCHOOL_MANAGEMENT_API1.Genarics;
using SCHOOL_MANAGEMENT_API1.Models;

namespace SCHOOL_MANAGEMENT_API1.AllCustoms.TeacherCustoms
{
    public class TeacherCustom : GenaricRepo<Teacher>, ITeacer
    {
        private readonly Context c;

        public TeacherCustom(Context c) : base(c)
        {
           this.c = c;
        }

        public List<Teacher> FilterTeachers(int departmentId, double minSalary)
        {
            return c.Teachers
                .Where(t => t.DepartmentId == departmentId && t.Salary > minSalary)
                .ToList();
        }

        public Teacher GetTeacherByEmail(string email)
        {
            return c.Teachers.FirstOrDefault(t => t.Email == email);
        }

        public bool HasSubjects(int teacherId)
        {
            return c.Subjects.Any(s => s.TeacherId == teacherId);
        }

        public dynamic GetTeacherNamesInDepartment(int departmentId)
        {
            return c.Teachers
                .Where(t => t.DepartmentId == departmentId)
                .Select(t => new { t.Id, FullName = t.FirstName + " " + t.LastName })
                .ToList();
        }

        public List<Teacher> GetTeachersOrderedBySalary()
        {
            return c.Teachers.OrderBy(t => t.Salary).ToList();
        }

        public List<Teacher> GetTeachersOrderedByDeptAndLastName()
        {
            return c.Teachers
                .OrderBy(t => t.DepartmentId)
                .ThenBy(t => t.LastName)
                .ToList();
        }

        public double GetAverageSalary(int departmentId)
        {
            return c.Teachers
                .Where(t => t.DepartmentId == departmentId)
                .Average(t => t.Salary);
        }

        public double GetMaxSalary(int departmentId)
        {
            return c.Teachers
                .Where(t => t.DepartmentId == departmentId)
                .Max(t => t.Salary);
        }

        public dynamic GroupTeachersByDepartment()
        {
            return c.Teachers
                .GroupBy(t => t.DepartmentId)
                .Select(g => new { DepartmentId = g.Key, Count = g.Count() })
                .ToList();
        }

        public List<int> GetDistinctDepartmentIds()
        {
            return c.Teachers
                .Select(t => t.DepartmentId)
                .Distinct()
                .ToList();
        }

        public List<int> GetUnionDepartmentTeacherIds(int dept1, int dept2)
        {
            var dept1Ids = c.Teachers.Where(t => t.DepartmentId == dept1).Select(t => t.Id);
            var dept2Ids = c.Teachers.Where(t => t.DepartmentId == dept2).Select(t => t.Id);
            return dept1Ids.Union(dept2Ids).ToList();
        }

        public List<int> GetExceptDepartmentTeacherIds(int dept1, int dept2)
        {
            var dept1Ids = c.Teachers.Where(t => t.DepartmentId == dept1).Select(t => t.Id);
            var dept2Ids = c.Teachers.Where(t => t.DepartmentId == dept2).Select(t => t.Id);
            return dept1Ids.Except(dept2Ids).ToList();
        }

        public Dictionary<int, string> GetTeachersDictionary(int departmentId)
        {
            return c.Teachers
                .Where(t => t.DepartmentId == departmentId)
                .ToDictionary(t => t.Id, t => t.FirstName + " " + t.LastName);
        }

        public IQueryable<Teacher> GetDeferredQuery(int departmentId)
        {
            return c.Teachers.Where(t => t.DepartmentId == departmentId);
        }

        public List<Teacher> SkipTeachers(int count)
        {
            return c.Teachers.OrderBy(t => t.Id).Skip(count).ToList();
        }

        public List<Teacher> GetPagedTeachers(int pageNumber, int pageSize, int departmentId, double minSalary)
        {
            return c.Teachers
                .Where(t => t.DepartmentId == departmentId && t.Salary > minSalary)
                .OrderBy(t => t.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }
    }
}
