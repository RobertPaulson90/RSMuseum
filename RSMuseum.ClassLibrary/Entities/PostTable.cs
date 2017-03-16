using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSMuseum.ClassLibrary.Entities
{
    public class PostTable
    {
        [Key]
        public int ZipCode { get; set; }

        public string City { get; set; }
    }
}
