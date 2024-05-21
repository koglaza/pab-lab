using Microsoft.EntityFrameworkCore;
using Web.Data;
using Web.Domain;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<WebContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("WebContext") ?? throw new InvalidOperationException("Connection string 'WebContext' not found.")));
var optionsDemoSection = builder.Configuration.GetSection("OptionsDemo");
builder.Services.Configure<OptionsDemoModel>(optionsDemoSection);

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.Run();
