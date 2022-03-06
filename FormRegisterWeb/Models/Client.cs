using System.ComponentModel.DataAnnotations;

namespace FormRegisterWeb.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        public int Phone { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; } 
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
}
