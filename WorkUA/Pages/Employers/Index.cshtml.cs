using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WorkUA.Data;
using WorkUA.Models;

namespace WorkUA.Pages.Employers {
    public class IndexModel : PageModel {
        private readonly DataContext _context;

        public IndexModel(DataContext context) {
            _context = context;
        }

        public IList<Employer> Employer { get; set; } = default!;

        public async Task OnGetAsync() {
            if (_context.Employer != null) {
                Employer = await _context.Employer
                    .Include(e => e.City).ToListAsync();
            }
        }
    }
}