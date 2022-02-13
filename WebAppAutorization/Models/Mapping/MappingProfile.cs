using AutoMapper;
using WebAppAutorization.Data.Identity;

namespace WebAppAutorization.Models.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Student, StudentModel>()
                .ForMember(dst => dst.BirthDate,
                opt => opt.MapFrom(src => src.BirthDate.Date));
                //.ForMember(dst => dst.FullName, 
                //opt => opt.MapFrom(src => src.Name + " " + src.Id));

            this.CreateMap<StudentModel, Student>();
        }
    }
}
