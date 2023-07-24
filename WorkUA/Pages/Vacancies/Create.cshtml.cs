using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WorkUA.Data;
using WorkUA.Models;

namespace WorkUA.Pages.Vacancies {
    public class CreateModel : PageModel {
        private readonly DataContext _context;

        public CreateModel(DataContext context) {
            _context = context;
        }

        public IActionResult OnGet() {
            ViewData["EmployerId"] = new SelectList(_context.Set<Employer>(), "Id", "Name");
            ViewData["ProfessionId"] = new SelectList(_context.Set<Profession>(), "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Vacancy Vacancy { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid || _context.Vacancy == null || Vacancy == null) {
                return Page();
            }

            _context.Vacancy.Add(Vacancy);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}