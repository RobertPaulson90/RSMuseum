using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSMuseum.ClassLibrary.Models
{
    public class TestModel : ITestModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public static int PrintAge(TestModel input)
        {
            return input.Age;
        }
    }
}