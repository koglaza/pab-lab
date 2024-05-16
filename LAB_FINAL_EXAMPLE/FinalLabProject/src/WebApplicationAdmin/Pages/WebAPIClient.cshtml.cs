using FinalLabProject.Application.TodoLists.Queries.GetTodos;
using FinalLabProject.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using RestSharp;
using RestSharp.Authenticators;
using WebApplicationAdmin.Config;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApplicationAdmin.Pages
{
    public class WebAPIClientModel : PageModel
    {
        private readonly ILogger<GrpcClientModel> _logger;
        private readonly IOptions<WebAPIConfig> _webAPIconfig;
        private readonly string TodoListUrl = "TodoLists";
        private readonly string UsersUrl = "Users";
        private string? _token { get; set; }
        public string? ResultMessage = string.Empty;

        public WebAPIClientModel(ILogger<GrpcClientModel> logger, IOptions<WebAPIConfig> webAPIconfig)
        {
            _logger = logger;
            _webAPIconfig = webAPIconfig;
            _token = string.Empty;
        }
        public void OnGet()
        {


        }

        public IActionResult OnPost()
        {

            // authorize to api - make sure the other project is running
            var client1 = new RestClient($"https://{this._webAPIconfig.Value.Host}:{this._webAPIconfig.Value.Port}");
            var request1 = new RestRequest($"api/{this.UsersUrl}/register", Method.Post);
            request1.AddHeader("content-type", "application/json");
            request1.AddJsonBody(new { email = "test@wsei.edu.pl", password = "StrongPass123$%^" });
            var response1 = client1.Execute(request1);

            var client2 = new RestClient($"https://{this._webAPIconfig.Value.Host}:{this._webAPIconfig.Value.Port}");
            var request2 = new RestRequest($"api/{this.UsersUrl}/login", Method.Post);
            request2.AddHeader("content-type", "application/json");
            request2.AddJsonBody(new { email = "test@wsei.edu.pl", password = "StrongPass123$%^" });
            var response2 = client2.Execute<AccessTokenResponse>(request2);
            _token = response2.Data?.AccessToken;

            if (null != _token)
            {
                var options = new RestClientOptions("http://example.com")
                {
                    Authenticator = new JwtAuthenticator(_token),
                    BaseUrl = new Uri($"https://{this._webAPIconfig.Value.Host}:{this._webAPIconfig.Value.Port}")

                };
                var client3 = new RestClient(options);
                var request3 = new RestRequest($"api/{this.TodoListUrl}", Method.Get);
                request3.AddHeader("content-type", "application/json");
                var response3 = client3.Execute<TodosVm>(request3);

                if (response3.IsSuccessful)
                {
                    this.ResultMessage = "Pomyślnie pobrano dane z API";
                }
                else if (response3 != null && response3.ErrorMessage != null)
                {
                    this.ResultMessage = response3.ErrorMessage;
                }
                else
                {
                    this.ResultMessage = "Nieoczekiwany błąd";
                }
            }
            else
            {
                this.ResultMessage = "Błąd autoryzacji";
            }
            return Page();
        }
    }
}
