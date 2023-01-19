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
    public class DeleteModel : PageModel
    {
        private readonly project.Data.projectContext _context;

        public DeleteModel(project.Data.projectContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Destinatie == null)
            {
                return NotFound();
            }
            var destinatie = await _context.Destinatie.FindAsync(id);

            if (destinatie != null)
            {
                Destinatie = destinatie;
                _context.Destinatie.Remove(Destinatie);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
