using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WorkUA.Data;
using WorkUA.Models;

namespace WorkUA.Pages.Vacancies {
    public class EditModel : PageModel {
        private readonly DataContext _context;

        public EditModel(DataContext context) {
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
            ViewData["EmployerId"] = new SelectList(_context.Set<Employer>(), "Id", "Name");
            ViewData["ProfessionId"] = new SelectList(_context.Set<Profession>(), "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid) {
                return Page();
            }

            _context.Attach(Vacancy).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) {
                if (!VacancyExists(Vacancy.Id)) {
                    return NotFound();
                }

                throw;
            }

            return RedirectToPage("./Index");
        }

        private bool VacancyExists(int id) {
            return (_context.Vacancy?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}