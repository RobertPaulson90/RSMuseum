using System.ComponentModel.DataAnnotations;

namespace RSMuseum.ClassLibrary.Entities
{
    public class Address
    {

        public Address()
        {
            Person = new Person();
        }
        public int Id { get; set; }

        public string Street { get; set; }

        public virtual ZipCodeTable ZipCodeId { get; set; }

        public virtual Person Person { get; set; }
    }
}