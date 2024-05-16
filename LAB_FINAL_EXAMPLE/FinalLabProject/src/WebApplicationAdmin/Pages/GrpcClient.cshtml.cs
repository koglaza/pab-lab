using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplicationAdmin.Pages;
public class GrpcClientModel : PageModel
{
    private readonly ILogger<GrpcClientModel> _logger;

    public GrpcClientModel(ILogger<GrpcClientModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        // implementacja klienta gRPC
        return Page();
    }
}

