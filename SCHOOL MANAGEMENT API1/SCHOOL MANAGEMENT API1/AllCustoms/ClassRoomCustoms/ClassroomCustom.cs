using Microsoft.EntityFrameworkCore;
using SCHOOL_MANAGEMENT_API1.Genarics;
using SCHOOL_MANAGEMENT_API1.Models;

namespace SCHOOL_MANAGEMENT_API1.AllCustoms.ClassRoomCustoms
{
    public class ClassroomCustom : GenaricRepo<ClassRoom>, IClassroom
    {
        private readonly Context c;
        public ClassroomCustom(Context c) : base(c)
        {
            this.c = c;
        }
        public ClassRoom GetFirstOrDefaultByCapacity(int minCapacity)
        {
        return  c.classRooms.FirstOrDefault(c => c.Capacity >= minCapacity);
        }
        public ClassRoom GetSingleOrDefaultByName(string name)
        { 

            return c.classRooms.SingleOrDefault(c => c.Name == name);
        }
        public ClassRoom GetClassroomAtIndex(int index)
        {
           return c.classRooms.OrderBy(c => c.Id).Skip(index).FirstOrDefault();
        }
        public bool CheckAllCapacityInGrade(int gradeLevel, int minCapacity)
        { 
           return c.classRooms.Where(c => c.GradeLevel == gradeLevel).All(c => c.Capacity >= minCapacity);
        }
        public int GetMinCapacityInGrade(int gradeLevel)
        { 
           return  c.classRooms.Where(c => c.GradeLevel == gradeLevel).Min(c => c.Capacity);
        }
        public ClassRoom[] GetClassroomsByGradeToArray(int gradeLevel)
        {
           return c.classRooms.Where(c => c.GradeLevel == gradeLevel).ToArray();
        }
        public List<ClassRoom> GetClassroomsWithImmediateExecution(int minCapacity)
        { 
          
           return c.classRooms.Where(c => c.Capacity >= minCapacity).ToList();
        }
    }
}
