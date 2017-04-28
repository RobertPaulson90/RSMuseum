using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSMuseum.Services.DTOs
{
    class RegistrationDTO : IRegistrationDTO
    {
        public int RegistrationId { get; set; }

        public int Hours { get; set; }

        public DateTime Date { get; set; }

        public bool Approved { get; set; }

        public bool Processed { get; set; }

        public IGuildDTO Guild { get; set; }

        public VolunteerViewDTO Volunteer { get; set; }

        public DateTime DateTimeRegistered { get; set; }
    }
}
