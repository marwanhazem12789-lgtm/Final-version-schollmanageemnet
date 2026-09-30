using SCHOOL_MANAGEMENT_API1.Genarics;
using SCHOOL_MANAGEMENT_API1.Models;

namespace SCHOOL_MANAGEMENT_API1.AllCustoms.DepartmentCustoms
{
    public interface IDepartment : IGenaricRepo<Department>
    {
        List<Subject> GetAllSubjectsInDepartment(int departmentId); 
    }
}
