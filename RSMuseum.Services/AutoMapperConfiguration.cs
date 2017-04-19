using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace RSMuseum.Services
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Map<Team, TeamDTO>()
                  .ForMember(dest => dest.Players, opt => opt.Ignore());
        }
    }
}
