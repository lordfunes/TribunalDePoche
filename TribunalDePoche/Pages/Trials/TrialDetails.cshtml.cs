using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore; 
using TribunalDePoche.Data;
using TribunalDePoche.Models;

namespace TribunalDePoche.Pages.Trials
{
    public class TrialDetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public TrialDetailsModel(ApplicationDbContext context) => _context = context;
        public Trial Trial { get; set; }
        public List<Prediction> Predictions { get; set; }
        public List<Comment> Comments { get; set; }
        public async Task OnGetAsync(int id)
        {
            Trial = await _context.Trials.FirstOrDefaultAsync(t => t.Id == id);
            Predictions = await _context.Predictions.Include(p => p.User).Where(p => p.TrialId == id).ToListAsync();
            Comments = await _context.Comments.Include(c => c.User).Where(c => c.TrialId == id).ToListAsync();
        }
    }
}