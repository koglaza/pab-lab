using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages
{
    public class EnvironmentModel : PageModel
    {
        private readonly ILogger<EnvironmentModel> _logger;

        public EnvironmentModel(ILogger<EnvironmentModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }

}
