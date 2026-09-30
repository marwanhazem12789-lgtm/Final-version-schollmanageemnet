using AutoMapper;
<<<<<<< HEAD
using SCHOOL_MANAGEMENT_API1.DTOS.EnrrolmentDto;
=======
using SCHOOL_MANAGEMENT_API1.DTOS.Enrollmentt;
>>>>>>> 2cc9e5f736dec4ba8beec69e6337d6fe8dc7c472
using SCHOOL_MANAGEMENT_API1.Models;

namespace SCHOOL_MANAGEMENT_API1.Mapping.EnrollmentMapping
{
    public class EnrollmentProfile : Profile
    {
        public EnrollmentProfile()
        {
<<<<<<< HEAD
            CreateMap<Enrollment, GetEnrollments>();
=======
            CreateMap<Enrollment, GetEnrollments>().ForMember(o => o.StudentName, opt => opt.MapFrom(src => $"{src.Student.FirstName} {src.Student.LastName}"))
                .ForMember(o => o.SubjectName, opt => opt.MapFrom(src => src.Subject.Name));


            CreateMap<Enrollment, GetEnrollmensById>().ForMember(o => o.StudentName, opt => opt.MapFrom(src => $"{src.Student.FirstName} {src.Student.LastName}"))
                .ForMember(o => o.SubjectName, opt => opt.MapFrom(src => src.Subject.Name));


            CreateMap<CreateEnrollment, Enrollment>();

            CreateMap<UpdateEnrollment, Enrollment>().ForMember(d => d.Id, opt => opt.Ignore());



>>>>>>> 2cc9e5f736dec4ba8beec69e6337d6fe8dc7c472
        }
    }
}
