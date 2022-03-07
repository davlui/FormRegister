using System.ComponentModel.DataAnnotations;

namespace FormRegisterWeb.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Preenchimento obrigatório")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Preenchimento obrigatório")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Preenchimento obrigatório")]
        [EmailAddress(ErrorMessage = "Não é um email válido.")]
        public string Email { get; set; }
        [RegularExpression(@"^(\d{9})$", ErrorMessage = "Não é um numero de telefone.")]
        public int? Phone { get; set; } 
        [Range(18,999,ErrorMessage = "Têm de ser maior de idade.")]
        public int? Age { get; set; }
        public string? Sex { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; } 
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
    }
}
