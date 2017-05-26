using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSMuseum.Services.DTOs
{
    public interface IRegistrationDto
    {
        int RegistrationId { get; set; }

        int Hours { get; set; }

        DateTime Date { get; set; }

        bool Approved { get; set; }

        bool Processed { get; set; }

        IGuildDTO Guild { get; set; }

        VolunteerViewDTO Volunteer { get; set; }

        DateTime DateTimeRegistered { get; set; }
    }
}