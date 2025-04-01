using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages; 
using TribunalDePoche.Data;
using TribunalDePoche.Models;

namespace TribunalDePoche.Pages.Predictions
{
    public class SubmitPredictionModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public SubmitPredictionModel(ApplicationDbContext context) => _context = context;
        [BindProperty]
        public Prediction Prediction { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();
            _context.Predictions.Add(Prediction);
            await _context.SaveChangesAsync();
            return RedirectToPage("TrialDetails", new { id = Prediction.TrialId });
        }
    }
}