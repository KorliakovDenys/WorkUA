using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkUA.Models {
    public class Employer {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int CityId { get; set; }

        [ForeignKey("CityId")]
        public City? City { get; set; }

        public ICollection<Vacancy> Vacancies = new List<Vacancy>();
    }
}