using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WorkUA.Data;
using WorkUA.Models;

namespace WorkUA.Pages.Vacancies {
    public class IndexModel : PageModel {
        private readonly DataContext _context;

        public IndexModel(DataContext context) {
            _context = context;
        }

        public IList<Vacancy> Vacancy { get; set; } = default!;

        public async Task OnGetAsync() {
            if (_context.Vacancy != null) {
                Vacancy = await _context.Vacancy
                    .Include(v => v.Employer)
                    .Include(v => v.Profession).ToListAsync();
            }
        }
    }
}