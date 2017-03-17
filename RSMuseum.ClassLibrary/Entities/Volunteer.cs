using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSMuseum.ClassLibrary.Entities
{
    public class Volunteer
    {
        [Key]
        public int Id { get; set; }
        public Volunteer()
        {
            Registrations = new List<Registration>();
        }
       
        public bool IsActive { get; set; }

        public virtual ICollection<Registration> Registrations { get; set; }
    }
}
