using System.Collections.Generic;
using RSMuseum.Services.DTOs;

namespace RSMuseum.Services
{
    public interface IGuildService
    {
        IList<IGuildDTO> GetAllGuilds();
    }
}