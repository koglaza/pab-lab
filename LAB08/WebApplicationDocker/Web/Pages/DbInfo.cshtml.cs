using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Web.Data;
using Web.Domain;

namespace Web.Pages
{
    public class DbInfoModel : PageModel
    {
        private readonly WebContext _context;

        public DbInfoModel(WebContext context)
        {
            _context = context;
        }

        public EnvironmentInfoModel EnvironmentInfoModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            var environmentinfomodel = await _context.EnvironmentInfoModel.FirstOrDefaultAsync();
            if (environmentinfomodel == null)
            {
                return NotFound();
            }
            else
            {
                EnvironmentInfoModel = environmentinfomodel;
            }
            return Page();
        }
    }
}
