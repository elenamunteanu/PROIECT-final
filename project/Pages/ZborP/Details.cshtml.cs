using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using project.Data;
using project.Models;

namespace project.Pages.ZborP
{
    public class DetailsModel : PageModel
    {
        private readonly project.Data.projectContext _context;

        public DetailsModel(project.Data.projectContext context)
        {
            _context = context;
        }

      public Plecari Plecari { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Plecari == null)
            {
                return NotFound();
            }

            var plecari = await _context.Plecari.FirstOrDefaultAsync(m => m.ID == id);
            if (plecari == null)
            {
                return NotFound();
            }
            else 
            {
                Plecari = plecari;
            }
            return Page();
        }
    }
}
