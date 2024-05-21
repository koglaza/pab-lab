using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages
{
    public class ExceptionModel : PageModel
    {
        private readonly ILogger<ExceptionModel> _logger;

        public ExceptionModel(ILogger<ExceptionModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            this._logger.LogInformation("Strona Exception została wyświetlona.");
        }
        public void OnPost()
        {
            this._logger.LogError("Wyjątek na stronie Exception.");
            throw new Exception("Błąd na życzenie ;-)");
        }
    }
}
