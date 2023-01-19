using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace project.Models
{
    public class Destinatie
    {
        public int ID { get; set; }

        [Display(Name = "Destinația")]
        public string DenumireOras { get; set; }
        public ICollection<Sosiri>? ZborS { get; set; } //navigation property
        public ICollection<Plecari>? ZborP { get; set; } //navigation property
    }
}
