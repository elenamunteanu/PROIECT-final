using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using project.Data;
using project.Models;

namespace project.Pages.Angajati
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly project.Data.projectContext _context;

        public EditModel(project.Data.projectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Angajat Angajat { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Angajat == null)
            {
                return NotFound();
            }

            var angajat =  await _context.Angajat.FirstOrDefaultAsync(m => m.ID == id);
            if (angajat == null)
            {
                return NotFound();
            }
            Angajat = angajat;
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

            _context.Attach(Angajat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AngajatExists(Angajat.ID))
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

        private bool AngajatExists(int id)
        {
          return _context.Angajat.Any(e => e.ID == id);
        }
    }
}
