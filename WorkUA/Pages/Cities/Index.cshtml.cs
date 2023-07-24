using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WorkUA.Data;
using WorkUA.Models;

namespace WorkUA.Pages.Cities {
    public class IndexModel : PageModel {
        private readonly DataContext _context;

        public IndexModel(DataContext context) {
            _context = context;
        }

        public IList<City> City { get; set; } = default!;

        public async Task OnGetAsync() {
            if (_context.City != null) {
                City = await _context.City.ToListAsync();
            }
        }
    }
}