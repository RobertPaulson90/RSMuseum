using System.ComponentModel.DataAnnotations;

namespace RSMuseum.ClassLibrary.Entities
{
    public class Address
    {
        public int AddressId { get; set; }

        public string Street { get; set; }

        public string CityCode { get; set; }

        public virtual Person Person { get; set; }
    }
}