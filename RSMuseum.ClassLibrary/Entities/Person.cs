using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSMuseum.ClassLibrary.Entities
{
    public class Person
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public virtual Address Adress  { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public virtual Guild Guild { get; set; }
    }
}
