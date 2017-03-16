using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSMuseum.ClassLibrary.Entities
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
        public int CurrentGuildId { get; set; }

        [Required]
        public int VolunteerId { get; set; }

        [Required]
        [ForeignKey("VolunteerId")]
        public virtual Volunteer Volunteer { get; set; }
    }
}
