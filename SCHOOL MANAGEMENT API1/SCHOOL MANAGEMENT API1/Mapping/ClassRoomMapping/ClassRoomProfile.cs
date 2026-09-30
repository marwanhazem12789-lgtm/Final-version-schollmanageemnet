using AutoMapper;
using SCHOOL_MANAGEMENT_API1.DTOS.ClassRoomDto;
using SCHOOL_MANAGEMENT_API1.DTOS.Department;
<<<<<<< HEAD
=======
using SCHOOL_MANAGEMENT_API1.DTOS.TeacherDtos;
>>>>>>> 2cc9e5f736dec4ba8beec69e6337d6fe8dc7c472
using SCHOOL_MANAGEMENT_API1.Models;

namespace SCHOOL_MANAGEMENT_API1.Mapping.ClassRoomMapping
{
    public class ClassRoomProfile : Profile
    {
        public ClassRoomProfile()
        {
<<<<<<< HEAD
            CreateMap<ClassRoom, GetClassRooms>();
=======
            CreateMap<ClassRoom, GetCalssRoooms>();
>>>>>>> 2cc9e5f736dec4ba8beec69e6337d6fe8dc7c472

            CreateMap<ClassRoom, GetClassRoomsById>();

            CreateMap<CreateClassRoom, ClassRoom>();

            CreateMap<UpdateClassRooom, ClassRoom>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
