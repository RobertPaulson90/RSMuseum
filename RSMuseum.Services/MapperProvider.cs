using AutoMapper;
using RSMuseum.Repository.Entities;
using RSMuseum.Services.DTOs;
using SimpleInjector;
using System.Linq;

namespace RSMuseum.Services
{
    // This class provides AutoMapper (including its configuration) to our DI Container.
    // Used for easily & cleanly mapping database entities with DTO's

    public class MapperProvider
    {
        private readonly Container _container;

        public MapperProvider(Container container)
        {
            _container = container;
        }

        public IMapper GetMapper()
        {
            var mapperCfg = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Guild, IGuildDTO>(); // Sometimes mapping is super easy, like this, when property names match

                cfg.CreateMap<Volunteer, IVolunteerViewDTO>()
                    .ForMember(
                        dest => dest.GuildName,
                        opts => opts.MapFrom(src => src.Guilds.Select(x => x.GuildName))) // Must manually find all the GuildName's
                    .ForMember( // Must manually bind First and Last name, since it is deeper in the Person object; not the Volunteer
                       dest => dest.FirstName,
                       opts => opts.MapFrom(src => src.Person.FirstName))
                     .ForMember(
                       dest => dest.LastName,
                       opts => opts.MapFrom(src => src.Person.LastName));

                cfg.CreateMap<Repository.Entities.Registration, IRegistrationDto>()
                    .ForMember(
                        dest => dest.Guild,
                        opts => opts.MapFrom(src => src.Guild))
                    .ForMember( /* There is an issue here for some reason :( Working on it: http://stackoverflow.com/questions/43676771/how-to-perform-map-when-mapping-relies-on-previous-map-config
                                   For now, we must manually map Registration <--> IRegistrationDTO, until there is a solution */
                        dest => dest.Volunteer,
                        opts => opts.MapFrom(src => src.Volunteer));
            });

            mapperCfg.AssertConfigurationIsValid();
            IMapper mapper = new Mapper(mapperCfg, t => _container.GetInstance(t));
            return mapper;
        }
    }
}