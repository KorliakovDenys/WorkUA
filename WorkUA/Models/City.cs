using System.ComponentModel.DataAnnotations;

namespace WorkUA.Models {
    public class City {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        
        public ICollection<Applicant> Applicants = new List<Applicant>();

        public ICollection<Employer> Employers = new List<Employer>();
    }
}