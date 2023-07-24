using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WorkUA.Data;
using WorkUA.Models;

namespace WorkUA.Pages.Professions {
    public class DetailsModel : PageModel {
        private readonly DataContext _context;

        public DetailsModel(DataContext context) {
            _context = context;
        }

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
    }
}