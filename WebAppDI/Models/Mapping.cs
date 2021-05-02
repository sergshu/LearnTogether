using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppDI.Data;

namespace WebAppDI.Models
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<TestItem, TestItemView>(MemberList.Destination)
                .ForMember(
                dst => dst.Date, 
                opt => opt.MapFrom(src => src.Date.ToString("dd.MM.yyyy HH:mm")));
        }
    }
}
