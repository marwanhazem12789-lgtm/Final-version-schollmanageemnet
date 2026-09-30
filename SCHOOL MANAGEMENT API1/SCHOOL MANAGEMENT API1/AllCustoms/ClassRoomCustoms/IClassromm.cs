using SCHOOL_MANAGEMENT_API1.Genarics;
using SCHOOL_MANAGEMENT_API1.Models;

namespace SCHOOL_MANAGEMENT_API1.AllCustoms.ClassRoomCustoms
{
    public interface IClassroom : IGenaricRepo<ClassRoom>
    {
        ClassRoom GetFirstOrDefaultByCapacity(int minCapacity); 
        ClassRoom GetSingleOrDefaultByName(string name); 
        ClassRoom GetClassroomAtIndex(int index);
        bool CheckAllCapacityInGrade(int gradeLevel, int minCapacity); 
        int GetMinCapacityInGrade(int gradeLevel); 
        ClassRoom[] GetClassroomsByGradeToArray(int gradeLevel); 
        List<ClassRoom> GetClassroomsWithImmediateExecution(int minCapacity);
    }
}
