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

namespace project.Pages.ZborP
{
    public class EditModel : PageModel
    {
        private readonly project.Data.projectContext _context;

        public EditModel(project.Data.projectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Plecari Plecari { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Plecari == null)
            {
                return NotFound();
            }

            var plecari =  await _context.Plecari.FirstOrDefaultAsync(m => m.ID == id);
            if (plecari == null)
            {
                return NotFound();
            }
            Plecari = plecari;
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

            _context.Attach(Plecari).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlecariExists(Plecari.ID))
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

        private bool PlecariExists(int id)
        {
          return _context.Plecari.Any(e => e.ID == id);
        }
    }
}
