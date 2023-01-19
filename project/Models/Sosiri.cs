using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace project.Models
{
    public class Sosiri
    {
        public int ID { get; set; }


        [Required]
        [RegularExpression(@"^\(?([0-9]{1})\)?[-]?([A-Z]{1})[ ]?([0-9]{3})$", ErrorMessage = "Numărul cursei trebuie să fie de forma 1X 234")]
        public string Ruta { get; set; }

       
        public int? DestinatieID { get; set; }
        public Destinatie? Destinatie { get; set; } //navigation property

        [Display(Name = "Ora programată")]
        [DataType(DataType.Time)] 
        public DateTime OraP { get; set; }

        [Display(Name = "Ora estimată")]
        [DataType(DataType.Time)]
        public DateTime OraE { get; set; }

        [Display(Name = "Statutul Zborului")]
        public string Statut { get; set; }

        public int? CompanieID { get; set; }
        public Companie? Companie { get; set; } //navigation property


    }
}
