using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserSoapServiceReference;

namespace WebApplicationAdmin.Pages
{
    public class SOAPClientModel : PageModel
    {
        private readonly ILogger<SOAPClientModel> _logger;
        public string SoapResult = string.Empty;    

        public SOAPClientModel(ILogger<SOAPClientModel> logger)
        {
            _logger = logger;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            IUserService soapServiceChannel = new UserServiceClient(UserServiceClient.EndpointConfiguration.BasicHttpBinding_IUserService);
            var registerUserResponse =  soapServiceChannel.RegisterUserAsync(new User()
            {
                FirstName = "Jan",
                LastName = "Kowalski",
                EmailAddress = "jankowalski@wsei.edu.pl",
                Age = 25,
                MarketingConsent = true
            }).Result;
            
            this.SoapResult = registerUserResponse; 
            return Page();
        }
    }
}
