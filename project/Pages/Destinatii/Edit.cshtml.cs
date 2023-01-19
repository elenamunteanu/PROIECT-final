using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using project.Data;
using project.Models;

namespace project.Pages.Destinatii
{
    public class EditModel : PageModel
    {
        private readonly project.Data.projectContext _context;

        public EditModel(project.Data.projectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Destinatie Destinatie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Destinatie == null)
            {
                return NotFound();
            }

            var destinatie =  await _context.Destinatie.FirstOrDefaultAsync(m => m.ID == id);
            if (destinatie == null)
            {
                return NotFound();
            }
            Destinatie = destinatie;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Destinatie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DestinatieExists(Destinatie.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DestinatieExists(int id)
        {
          return _context.Destinatie.Any(e => e.ID == id);
        }
    }
}
