using System.ComponentModel.DataAnnotations;

namespace RSMuseum.Repository.Entities
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }

        public string Street { get; set; }

        [Required]
        public int ZipCodeTableId { get; set; }

        public virtual ZipCodeTable ZipCode { get; set; }

        //public virtual Person Person { get; set; }
    }
}