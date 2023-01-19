using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using project.Data;
using project.Models;

namespace project.Pages.Companii
{
    public class IndexModel : PageModel
    {
        private readonly project.Data.projectContext _context;

        public IndexModel(project.Data.projectContext context)
        {
            _context = context;
        }

        public IList<Companie> Companie { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Companie != null)
            {
                Companie = await _context.Companie.ToListAsync();
            }
        }
    }
}
