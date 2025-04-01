using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TribunalDePoche.Data; 
using TribunalDePoche.Models;

namespace TribunalDePoche.Pages.Celebrities
{
    public class CelebrityDetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public CelebrityDetailsModel(ApplicationDbContext context) => _context = context;

        public Celebrity Celebrity { get; set; }

        public async Task OnGetAsync(int id)
        {
            Celebrity = await _context.Celebrities
                .Include(c => c.Trials)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
