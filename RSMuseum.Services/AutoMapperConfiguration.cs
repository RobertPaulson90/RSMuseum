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
                cfg.CreateMap<List<Volunteer>, List<VolunteerViewDTO>>();
            });

            Mapper = config.CreateMapper();
        }
    }
}
