using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WorkUA.Data;
using WorkUA.Models;

namespace WorkUA.Pages.Applicants {
    public class DeleteModel : PageModel {
        private readonly DataContext _context;

        public DeleteModel(DataContext context) {
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

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id) {
            if (id == null || _context.Applicant == null) {
                return NotFound();
            }

            var applicant = await _context.Applicant.Include(a => a.City).Include(a => a.Profession)
                .FirstOrDefaultAsync(m => m.Id == id);
            
            if (applicant == null) return RedirectToPage("./Index");

            Applicant = applicant;
            _context.Applicant.Remove(Applicant);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}