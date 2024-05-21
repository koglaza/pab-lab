using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages
{
    public class AddMessageModel : PageModel
    {
        
        public void OnGet()
        {
        }

        [BindProperty]
        public string Message { get; set; }
        public void OnPost()
        {

        }
    }
}
