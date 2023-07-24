using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WorkUA.Data;
using WorkUA.Models;

namespace WorkUA.Pages.Vacancies {
    public class DetailsModel : PageModel {
        private readonly DataContext _context;

        public DetailsModel(DataContext context) {
            _context = context;
        }

        public Vacancy Vacancy { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id) {
            if (id == null || _context.Vacancy == null) {
                return NotFound();
            }

            var vacancy = await _context.Vacancy.Include(v => v.Employer).Include(v => v.Profession).Include(v => v.Employer!.City)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vacancy == null) {
                return NotFound();
            }

            Vacancy = vacancy;

            return Page();
        }
    }
}