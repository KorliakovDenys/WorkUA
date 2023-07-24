using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WorkUA.Data;
using WorkUA.Models;

namespace WorkUA.Pages.Employers {
    public class DeleteModel : PageModel {
        private readonly DataContext _context;

        public DeleteModel(DataContext context) {
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

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id) {
            if (id == null || _context.Employer == null) {
                return NotFound();
            }

            var employer = await _context.Employer.FindAsync(id);

            if (employer != null) {
                Employer = employer;
                _context.Employer.Remove(Employer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}