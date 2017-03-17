using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSMuseum.ClassLibrary.Entities
{
    public class ZipCodeTable
    {
        [Key]
        public int ZipCodeId { get; set; }

        [Required]
        public int ZipCode { get; set; }

        [Required]
        public string City { get; set; }
    }

    
}
