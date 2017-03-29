using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSMuseum.Repository.Entities
{
    public class Registration
    {
        [Required]
        public int RegistrationId { get; set; }

        [Required]
        public int Hours { get; set; }

        [Required]
        public bool Approved { get; set; }

        [Required]
        public int GuildId { get; set; }

        public virtual Guild Guild { get; set; }

        [Required]
        public int VolunteerId { get; set; }

        public virtual Volunteer Volunteer { get; set; }
    }
}