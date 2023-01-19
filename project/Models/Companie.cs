using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace project.Models
{
    public class Companie
    {
        public int ID { get; set; }
        
        [Display(Name = "Compania aeriană")]
        public string DenumireCompanie { get; set; }
        public ICollection<Sosiri>? ZborS { get; set; } //navigation property
        public ICollection<Plecari>? ZborP { get; set; } //navigation property   
    }
}
