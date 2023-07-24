using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WorkUA.Data;
using WorkUA.Models;

namespace WorkUA.Pages.Cities {
    public class EditModel : PageModel {
        private readonly DataContext _context;

        public EditModel(DataContext context) {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid) {
                return Page();
            }

            _context.Attach(City).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) {
                if (!CityExists(City.Id)) {
                    return NotFound();
                }

                throw;
            }

            return RedirectToPage("./Index");
        }

        private bool CityExists(int id) {
            return (_context.City?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}