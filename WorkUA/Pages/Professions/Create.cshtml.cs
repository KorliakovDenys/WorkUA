using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WorkUA.Data;
using WorkUA.Models;

namespace WorkUA.Pages.Professions {
    public class CreateModel : PageModel {
        private readonly DataContext _context;

        public CreateModel(DataContext context) {
            _context = context;
        }

        public IActionResult OnGet() {
            return Page();
        }

        [BindProperty]
        public Profession Profession { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid || _context.Profession == null || Profession == null) {
                return Page();
            }

            _context.Profession.Add(Profession);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}