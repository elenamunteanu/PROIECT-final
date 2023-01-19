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
    public class DetailsModel : PageModel
    {
        private readonly project.Data.projectContext _context;

        public DetailsModel(project.Data.projectContext context)
        {
            _context = context;
        }

      public Destinatie Destinatie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Destinatie == null)
            {
                return NotFound();
            }

            var destinatie = await _context.Destinatie.FirstOrDefaultAsync(m => m.ID == id);
            if (destinatie == null)
            {
                return NotFound();
            }
            else 
            {
                Destinatie = destinatie;
            }
            return Page();
        }
    }
}
