using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using project.Data;
using project.Models;

namespace project.Pages.ZborS
{
    public class EditModel : PageModel
    {
        private readonly project.Data.projectContext _context;

        public EditModel(project.Data.projectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Sosiri Sosiri { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Sosiri == null)
            {
                return NotFound();
            }

            var sosiri =  await _context.Sosiri.FirstOrDefaultAsync(m => m.ID == id);
            if (sosiri == null)
            {
                return NotFound();
            }
            Sosiri = sosiri;
            ViewData["DestinatieID"] = new SelectList(_context.Set<Destinatie>(), "ID", "DenumireOras");
            ViewData["CompanieID"] = new SelectList(_context.Set<Companie>(), "ID", "DenumireCompanie");
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

            _context.Attach(Sosiri).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SosiriExists(Sosiri.ID))
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

        private bool SosiriExists(int id)
        {
          return _context.Sosiri.Any(e => e.ID == id);
        }
    }
}
