using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WorkUA.Data;
using WorkUA.Models;

namespace WorkUA.Pages.Professions {
    public class EditModel : PageModel {
        private readonly DataContext _context;

        public EditModel(DataContext context) {
            _context = context;
        }

        [BindProperty]
        public Profession Profession { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id) {
            if (id == null || _context.Profession == null) {
                return NotFound();
            }

            var profession = await _context.Profession.FirstOrDefaultAsync(m => m.Id == id);
            if (profession == null) {
                return NotFound();
            }

            Profession = profession;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid) {
                return Page();
            }

            _context.Attach(Profession).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) {
                if (!ProfessionExists(Profession.Id)) {
                    return NotFound();
                }

                throw;
            }

            return RedirectToPage("./Index");
        }

        private bool ProfessionExists(int id) {
            return (_context.Profession?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}