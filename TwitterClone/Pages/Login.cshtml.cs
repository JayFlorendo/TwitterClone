using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using TwitterClone.Models;
using TwitterClone.Data;

namespace TwitterClone.Pages
{
    public class LoginModel : PageModel
    {

        private readonly TwitterClone.Data.TwitterCloneContext _context;

        public LoginModel(TwitterClone.Data.TwitterCloneContext context)
        {
            _context = context;
        }

        public Users Users { get; set; }

        public void OnGet()
        {
        }

        public class Credentials
        {
            public string? Username { get; set; }
            public string? Password { get; set; }
        }

        public IActionResult OnPost()
        {
            Credentials credentials = new Credentials();
            credentials.Username = Request.Form["Username"];
            credentials.Password = Request.Form["Password"];

            if (credentials.Username != "" && credentials.Password != "")
            {
                try
                {

                    
                    Users = _context.Users.FirstOrDefault(x => x.Username == credentials.Username);

                    if (Users.Password == credentials.Password)
                    {
                        return RedirectToPage("Home", new { id = Users.ID, action = "none" });
                    } else
                    {
                        ViewData["error"] = $"Wrong Username/Password";
                    }
                   
                } catch (NullReferenceException ex)
                {
                    ViewData["error"] = $"Wrong Username/Password";
                }
                return Page();

            } else
            {
                ViewData["error"] = $"Wrong Username/Password!";
                return Page();
            }


        }
    }
}
