using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WorkUA.Data;
using WorkUA.Models;

namespace WorkUA.Pages.Professions {
    public class IndexModel : PageModel {
        private readonly DataContext _context;

        public IndexModel(DataContext context) {
            _context = context;
        }

        public IList<Profession> Profession { get; set; } = default!;

        public async Task OnGetAsync() {
            if (_context.Profession != null) {
                Profession = await _context.Profession.ToListAsync();
            }
        }
    }
}