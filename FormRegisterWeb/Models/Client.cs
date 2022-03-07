using System.ComponentModel.DataAnnotations;

namespace FormRegisterWeb.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Nome")]
        [Required(ErrorMessage = "Preenchimento obrigatório")]
        public string FirstName { get; set; }

        [Display(Name = "Apelido")]
        [Required(ErrorMessage = "Preenchimento obrigatório")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Preenchimento obrigatório")]
        [EmailAddress(ErrorMessage = "Não é um email válido.")]
        public string Email { get; set; }
        
        [Display(Name = "Contacto")]

        [RegularExpression(@"^(\d{9})$", ErrorMessage = "Não é um numero de telefone.")]
        public int? Phone { get; set; } 
        
        [Range(18,999,ErrorMessage = "Têm de ser maior de idade.")]
        [Display(Name = "Idade")]
        public int? Age { get; set; }

        [Display(Name = "Sexo")]
        public string? Sex { get; set; }

        [Display(Name = "Morada")]
        public string? Address { get; set; }

        [Display(Name = "Localidade")]
        public string? City { get; set; }

        [Display(Name = "Código Postal")]
        public string? PostalCode { get; set; }

        [Display(Name = "Pais")]
        public string? Country { get; set; }
    }
}
