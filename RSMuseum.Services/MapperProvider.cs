using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration;
using RSMuseum.Repository.Entities;
using RSMuseum.Services.DTOs;
using SimpleInjector;

namespace RSMuseum.Services
{
    public class MapperProvider
    {
        private readonly Container _container;

        public MapperProvider(Container container)
        {
            _container = container;
        }

        public IMapper GetMapper()
        {
            var mc = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Volunteer, IVolunteerViewDTO>()
                  .ForMember(dest => dest.GuildName,
                 opts => opts.MapFrom(src => src.Guilds.Select(x => x.GuildName)))
                 .ForMember(dest => dest.FirstName,
                 opts => opts.MapFrom(src => src.Person.FirstName))
                  .ForMember(dest => dest.LastName,
                 opts => opts.MapFrom(src => src.Person.LastName));

                cfg.CreateMap<Guild, IGuildDTO>();

                cfg.CreateMap<Repository.Entities.Registration, IRegistrationDTO>()
                    .ForMember(dest => dest.Guild,
                        opts => opts.MapFrom(src => src.Guild))
                //.ForMember(dest => dest.Volunteer,
                //    opts => opts.MapFrom(src => src.Volunteer))
                ;
            });

            mc.AssertConfigurationIsValid();

            IMapper m = new Mapper(mc, t => _container.GetInstance(t));

            return m;
        }
    }
}