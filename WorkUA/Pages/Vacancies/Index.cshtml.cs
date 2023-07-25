using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WorkUA.Data;
using WorkUA.Models;

namespace WorkUA.Pages.Vacancies {
    public class IndexModel : PageModel {
        private readonly DataContext _context;

        public IndexModel(DataContext context) {
            _context = context;
        }

        public IList<Vacancy>? Vacancy { get; set; }

        public IEnumerable<City> Cities => _context.City!.ToList();

        public IEnumerable<Profession> Professions => _context.Profession!.ToList();

        [BindProperty]
        public int CityIdFilter { get; set; }

        [BindProperty]
        public int ProfessionIdFilter { get; set; }

        [BindProperty]
        public bool IsRemoteFilter { get; set; }

        [BindProperty]
        public bool IsNotRemoteFilter { get; set; }

        public async Task OnGetAsync(int cityIdFilter, int professionIdFilter, bool isRemoteFilter,
            bool isNotRemoteFilter) {
            CityIdFilter = cityIdFilter;
            ProfessionIdFilter = professionIdFilter;
            IsRemoteFilter = isRemoteFilter;
            IsNotRemoteFilter = isNotRemoteFilter;

            if (_context.Vacancy != null) {
                var value = await _context.Vacancy
                    .Include(v => v.Employer)
                    .Include(v => v.Profession).ToListAsync();

                if (CityIdFilter != 0) {
                    value = value.Where(v => v.Employer!.CityId == CityIdFilter).ToList();
                }

                if (ProfessionIdFilter != 0) {
                    value = value.Where(v => v.ProfessionId == ProfessionIdFilter).ToList();
                }

                if (IsRemoteFilter && !isNotRemoteFilter) {
                    value = value.Where(v => v.IsRemote).ToList();
                }

                if (IsNotRemoteFilter && !isRemoteFilter) {
                    value = value.Where(v => !v.IsRemote).ToList();
                }

                ViewData["Cities"] = new SelectList(Cities, "Id", "Name");
                ViewData["Professions"] = new SelectList(Professions, "Id", "Name");

                Vacancy = value;
            }
        }
    }
}