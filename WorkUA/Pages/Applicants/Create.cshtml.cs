using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WorkUA.Data;
using WorkUA.Models;

namespace WorkUA.Pages.Applicants {
    public class CreateModel : PageModel {
        private readonly DataContext _context;

        public CreateModel(DataContext context) {
            _context = context;
        }

        public IActionResult OnGet() {
            ViewData["CityId"] = new SelectList(_context.Set<City>(), "Id", "Name");
            ViewData["ProfessionId"] = new SelectList(_context.Set<Profession>(), "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Applicant Applicant { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid || _context.Applicant == null || Applicant == null) {
                return Page();
            }

            _context.Applicant.Add(Applicant);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}