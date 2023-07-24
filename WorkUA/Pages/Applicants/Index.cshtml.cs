using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WorkUA.Data;
using WorkUA.Models;

namespace WorkUA.Pages.Applicants {
    public class IndexModel : PageModel {
        private readonly DataContext _context;

        public IndexModel(DataContext context) {
            _context = context;
        }

        public IList<Applicant> Applicant { get; set; } = default!;

        public async Task OnGetAsync() {
            if (_context.Applicant != null) {
                Applicant = await _context.Applicant
                    .Include(a => a.City)
                    .Include(a => a.Profession).ToListAsync();
            }
        }
    }
}