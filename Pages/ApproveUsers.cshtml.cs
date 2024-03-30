using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OnlineInternship.Models;

namespace OnlineInternship.Pages
{
    [Authorize(Roles = "admin")]
    public class ApproveUsersModel : PageModel
    {
          
            private readonly UserManager<ApplicationUser> _userManager;

            public ApproveUsersModel(UserManager<ApplicationUser> userManager)
            {
                _userManager = userManager;
            }

            public List<ApplicationUser>? AllUsers { get; set; }
            public void OnGet()
              {
                AllUsers = _userManager.Users.ToList();
             }

        
        public async Task<IActionResult> OnPostApproveUser(string userId, bool approved)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            user.Approved = approved;
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToPage(); // Redirect to the same page after updating the user
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return Page(); // Stay on the same page and display any errors
            }
        }
    }
}
