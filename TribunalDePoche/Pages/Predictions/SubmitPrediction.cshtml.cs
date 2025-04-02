using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TribunalDePoche.Data;
using TribunalDePoche.Models;
using System.Threading.Tasks;

namespace TribunalDePoche.Pages.Predictions
{
    public class SubmitPredictionModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public SubmitPredictionModel(ApplicationDbContext context) => _context = context;

        [BindProperty]
        public Prediction Prediction { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Prepopulate TrialId from route data
            Prediction = new Prediction
            {
                TrialId = id.Value
            };

            // You can get the Trial details if needed
            var trial = await _context.Trials.FindAsync(id);
            if (trial == null)
            {
                return NotFound();
            }

            // Optionally set some other properties, e.g., user
            // Assuming you have a logged-in user, set the UserId here
            // For example, if you're using Identity:
            // Prediction.UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            // Or if you manually set the UserId, just set it here:
            Prediction.UserId = 1; // Placeholder, set this dynamically based on logged-in user

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Save Prediction (make sure to set UserId and TrialId)
            _context.Predictions.Add(Prediction);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Trials/TrialDetails", new { id = Prediction.TrialId });

        }
    }
}
