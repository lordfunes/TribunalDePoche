using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TribunalDePoche.Data; 
using TribunalDePoche.Models;

namespace TribunalDePoche.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public IndexModel(ApplicationDbContext context) => _context = context;
        public List<Celebrity> Celebrities { get; set; }
        public async Task OnGetAsync() => Celebrities = await _context.Celebrities.ToListAsync();
    }
}