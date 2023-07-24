using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WorkUA.Data;
using WorkUA.Models;

namespace WorkUA.Pages.Professions {
    public class DeleteModel : PageModel {
        private readonly DataContext _context;

        public DeleteModel(DataContext context) {
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

        public async Task<IActionResult> OnPostAsync(int? id) {
            if (id == null || _context.Profession == null) {
                return NotFound();
            }

            var profession = await _context.Profession.FindAsync(id);

            if (profession != null) {
                Profession = profession;
                _context.Profession.Remove(Profession);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}