using SCHOOL_MANAGEMENT_API1.Genarics;
using SCHOOL_MANAGEMENT_API1.Models;
using System.Collections.Generic;
using System.Linq;

namespace SCHOOL_MANAGEMENT_API1.AllCustoms.TeacherCustoms
{
    public interface ITeacer : IGenaricRepo<Teacher>
    {
        List<Teacher> FilterTeachers(int departmentId, double minSalary);
        Teacher GetTeacherByEmail(string email);
        bool HasSubjects(int teacherId);
        dynamic GetTeacherNamesInDepartment(int departmentId);
        List<Teacher> GetTeachersOrderedBySalary();
        List<Teacher> GetTeachersOrderedByDeptAndLastName();
        double GetAverageSalary(int departmentId);
        double GetMaxSalary(int departmentId);
        dynamic GroupTeachersByDepartment();
        List<int> GetDistinctDepartmentIds();
        List<int> GetUnionDepartmentTeacherIds(int dept1, int dept2);
        List<int> GetExceptDepartmentTeacherIds(int dept1, int dept2);
        Dictionary<int, string> GetTeachersDictionary(int departmentId);
        IQueryable<Teacher> GetDeferredQuery(int departmentId);
        List<Teacher> SkipTeachers(int count);
        List<Teacher> GetPagedTeachers(int pageNumber, int pageSize, int departmentId, double minSalary);
    }
}