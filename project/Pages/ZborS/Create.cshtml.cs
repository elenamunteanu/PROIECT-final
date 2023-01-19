using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using project.Data;
using project.Models;

namespace project.Pages.ZborS
{
    public class CreateModel : PageModel
    {
        private readonly project.Data.projectContext _context;

        public CreateModel(project.Data.projectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["DestinatieID"] = new SelectList(_context.Set<Destinatie>(), "ID", "DenumireOras");
            ViewData["CompanieID"] = new SelectList(_context.Set<Companie>(), "ID", "DenumireCompanie");
            return Page();
        }

        [BindProperty]
        public Sosiri Sosiri { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Sosiri.Add(Sosiri);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
