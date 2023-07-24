using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WorkUA.Data;
using WorkUA.Models;

namespace WorkUA.Pages.Employers {
    public class EditModel : PageModel {
        private readonly DataContext _context;

        public EditModel(DataContext context) {
            _context = context;
        }

        [BindProperty]
        public Employer Employer { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id) {
            if (id == null || _context.Employer == null) {
                return NotFound();
            }

            var employer = await _context.Employer.FirstOrDefaultAsync(m => m.Id == id);
            if (employer == null) {
                return NotFound();
            }

            Employer = employer;
            ViewData["CityId"] = new SelectList(_context.Set<City>(), "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid) {
                return Page();
            }

            _context.Attach(Employer).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) {
                if (!EmployerExists(Employer.Id)) {
                    return NotFound();
                }

                throw;
            }

            return RedirectToPage("./Index");
        }

        private bool EmployerExists(int id) {
            return (_context.Employer?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}