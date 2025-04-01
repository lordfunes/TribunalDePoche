using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages; 
using TribunalDePoche.Data;
using TribunalDePoche.Models;

namespace TribunalDePoche.Pages.Comments
{
    public class SubmitCommentModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public SubmitCommentModel(ApplicationDbContext context) => _context = context;
        [BindProperty]
        public Comment Comment { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();
            _context.Comments.Add(Comment);
            await _context.SaveChangesAsync();
            return RedirectToPage("TrialDetails", new { id = Comment.TrialId });
        }
    }
}