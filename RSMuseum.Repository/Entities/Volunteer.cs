using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSMuseum.Repository.Entities
{
    public class Volunteer
    {
        public int VolunteerId { get; set; }

        public int MembershipNumber { get; set; }
        public bool IsActive { get; set; }

        public virtual IList<Registration> Registrations { get; set; }
        public virtual IList<Guild> Guilds { get; set; }

        [Required]
        public int PersonId { get; set; }

        public virtual Person Person { get; set; }
    }
}