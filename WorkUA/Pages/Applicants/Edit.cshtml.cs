using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WorkUA.Data;
using WorkUA.Models;

namespace WorkUA.Pages.Applicants {
    public class EditModel : PageModel {
        private readonly DataContext _context;

        public EditModel(DataContext context) {
            _context = context;
        }

        [BindProperty]
        public Applicant Applicant { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id) {
            if (id == null || _context.Applicant == null) {
                return NotFound();
            }

            var applicant = await _context.Applicant.FirstOrDefaultAsync(m => m.Id == id);
            if (applicant == null) {
                return NotFound();
            }

            Applicant = applicant;
            ViewData["CityId"] = new SelectList(_context.Set<City>(), "Id", "Name");
            ViewData["ProfessionId"] = new SelectList(_context.Set<Profession>(), "Id", "Name");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid) {
                return Page();
            }

            _context.Attach(Applicant).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) {
                if (!ApplicantExists(Applicant.Id)) {
                    return NotFound();
                }

                throw;
            }

            return RedirectToPage("./Index");
        }

        private bool ApplicantExists(int id) {
            return (_context.Applicant?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}