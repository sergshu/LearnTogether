using AutoMapper;
using WebAppAutorization.Data.Identity;

namespace WebAppAutorization.Models.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Student, StudentModel>();
        }
    }
}
