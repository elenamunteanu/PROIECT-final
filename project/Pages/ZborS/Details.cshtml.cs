using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using project.Data;
using project.Models;

namespace project.Pages.ZborS
{
    public class DetailsModel : PageModel
    {
        private readonly project.Data.projectContext _context;

        public DetailsModel(project.Data.projectContext context)
        {
            _context = context;
        }

      public Sosiri Sosiri { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Sosiri == null)
            {
                return NotFound();
            }

            var sosiri = await _context.Sosiri.FirstOrDefaultAsync(m => m.ID == id);
            if (sosiri == null)
            {
                return NotFound();
            }
            else 
            {
                Sosiri = sosiri;
            }
            return Page();
        }
    }
}
