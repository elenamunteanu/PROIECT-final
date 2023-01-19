using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using project.Data;
using project.Models;

namespace project.Pages.Destinatii
{
    public class IndexModel : PageModel
    {
        private readonly project.Data.projectContext _context;

        public IndexModel(project.Data.projectContext context)
        {
            _context = context;
        }

        public IList<Destinatie> Destinatie { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Destinatie != null)
            {
                Destinatie = await _context.Destinatie.ToListAsync();
            }
        }
    }
}
