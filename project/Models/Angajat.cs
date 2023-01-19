using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace project.Models
{
    public class Angajat
    {
        public int ID { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage = "Prenumele trebuie sa inceapa cu majuscula")]
        [StringLength(30, MinimumLength = 3)]
        public string? Prenume { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", ErrorMessage = "Prenumele trebuie sa inceapa cu majuscula")]
        [StringLength(30, MinimumLength = 3)]
        public string? Nume { get; set; }


        [Required]
        [StringLength(70)]
        public string? Adresa { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^\(?([0-9]{4})\)?[-]?([0-9]{3})[-]?([0-9]{3})$", ErrorMessage = "Telefonul trebuie sa fie de forma '0722-123-123'")]
        public string? Telefon { get; set; }
       
       
    }
}
