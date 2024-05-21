using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Web.Domain;

namespace Web.Pages
{
    public class OptionsModel : PageModel
    {
        public OptionsDemoModel OptionsDemo;
        public OptionsModel(IOptions<OptionsDemoModel> options)
        {
            this.OptionsDemo = options.Value;
        }
        public void OnGet()
        {
        }
    }
}
