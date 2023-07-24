using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WorkUA.Data;
using WorkUA.Models;

namespace WorkUA.Pages.Vacancies {
    public class DeleteModel : PageModel {
        private readonly DataContext _context;

        public DeleteModel(DataContext context) {
            _context = context;
        }

        [BindProperty]
        public Vacancy Vacancy { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id) {
            if (id == null || _context.Vacancy == null) {
                return NotFound();
            }

            var vacancy = await _context.Vacancy.FirstOrDefaultAsync(m => m.Id == id);

            if (vacancy == null) {
                return NotFound();
            }

            Vacancy = vacancy;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id) {
            if (id == null || _context.Vacancy == null) {
                return NotFound();
            }

            var vacancy = await _context.Vacancy.Include(v => v.Employer).Include(v => v.Profession)
                .Include(v => v.Employer!.City)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (vacancy == null) return RedirectToPage("./Index");
            Vacancy = vacancy;
            _context.Vacancy.Remove(Vacancy);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}