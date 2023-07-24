using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkUA.Models {
    public class Applicant {
        [Key]
        public int Id { get; set; }

        public string Surname { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public int Experience { get; set; }

        public int CityId { get; set; }

        [ForeignKey("CityId")]
        public City? City { get; set; }

        public int ProfessionId { get; set; }

        [ForeignKey("ProfessionId")]
        public Profession? Profession { get; set; }
    }
}