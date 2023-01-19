﻿using System;
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
    public class DeleteModel : PageModel
    {
        private readonly project.Data.projectContext _context;

        public DeleteModel(project.Data.projectContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Sosiri == null)
            {
                return NotFound();
            }
            var sosiri = await _context.Sosiri.FindAsync(id);

            if (sosiri != null)
            {
                Sosiri = sosiri;
                _context.Sosiri.Remove(Sosiri);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
