using System.ComponentModel.DataAnnotations;

namespace WorkUA.Models {
    public class Profession {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        
        public ICollection<Applicant> Applicants = new List<Applicant>();

        public ICollection<Vacancy> Vacancies = new List<Vacancy>();
    }
}