using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkUA.Models {
    public class Vacancy {
        [Key]
        public int Id { get; set; }

        public bool IsRemote { get; set; }

        public int? ProfessionId { get; set; }

        [ForeignKey("ProfessionId")]
        public Profession? Profession { get; set; }

        public int EmployerId { get; set; }

        [ForeignKey("EmployerId")]
        public Employer? Employer { get; set; }
    }
}