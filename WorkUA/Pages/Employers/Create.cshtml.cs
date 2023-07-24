using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WorkUA.Data;
using WorkUA.Models;

namespace WorkUA.Pages.Employers {
    public class CreateModel : PageModel {
        private readonly DataContext _context;

        public CreateModel(DataContext context) {
            _context = context;
        }

        public IActionResult OnGet() {
            ViewData["CityId"] = new SelectList(_context.Set<City>(), "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Employer Employer { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid || _context.Employer == null || Employer == null) {
                return Page();
            }

            _context.Employer.Add(Employer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}