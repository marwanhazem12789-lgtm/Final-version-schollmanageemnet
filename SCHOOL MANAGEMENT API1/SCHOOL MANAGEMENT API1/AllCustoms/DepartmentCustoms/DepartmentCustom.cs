using Microsoft.EntityFrameworkCore;
using SCHOOL_MANAGEMENT_API1.AllCustoms.DepartmentCustoms;
using SCHOOL_MANAGEMENT_API1.Genarics;
using SCHOOL_MANAGEMENT_API1.Models;
using System.Runtime.InteropServices;

namespace SCHOOL_MANAGEMENT_API1.AllCustoms.DepartmentCustoms
{
    public class DepartmentCustom : GenaricRepo<Department> , IDepartment
    {
        private readonly Context c; 
        public DepartmentCustom(Context c):base(c)
        {
            this.c = c;
            
        }
        public List<Subject> GetAllSubjectsInDepartment(int departmentId)
        {
            return c.Teachers
                .Where(t => t.DepartmentId == departmentId)
                .SelectMany(t => t.Subjects)
                .ToList();
        }
    }
}
