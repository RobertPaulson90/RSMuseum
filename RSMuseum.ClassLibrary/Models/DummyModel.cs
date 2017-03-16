using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSMuseum.ClassLibrary.Models
{
     public class DummyModel : IDummyModel
    {
        public int Age { get; set; }
        public DummyModel()
        {
            this.Age = 15;
        }
    }
}
