using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WorkUA.Data;
using WorkUA.Models;

namespace WorkUA.Pages.Cities {
    public class DetailsModel : PageModel {
        private readonly DataContext _context;

        public DetailsModel(DataContext context) {
            _context = context;
        }

        public City City { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id) {
            if (id == null || _context.City == null) {
                return NotFound();
            }

            var city = await _context.City.FirstOrDefaultAsync(m => m.Id == id);
            if (city == null) {
                return NotFound();
            }

            City = city;

            return Page();
        }
    }
}