using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using RSMuseum.Repository.Entities;
using RSMuseum.Services.DTOs;

namespace RSMuseum.Services
{
    public class AutoMapperConfiguration
    {
        public static IMapper Mapper { get; set; }

        public AutoMapperConfiguration()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Volunteer, IVolunteerViewDTO>()
                .ForMember(dest => dest.GuildName,
               opts => opts.MapFrom(src => src.Guilds.Select(x => x.GuildName)))
               .ForMember(dest => dest.FirstName,
               opts => opts.MapFrom(src => src.Person.FirstName))
                .ForMember(dest => dest.LastName,
               opts => opts.MapFrom(src => src.Person.LastName));
            });

            AutoMapperConfiguration.Mapper = config.CreateMapper();            
        }
    }
}
