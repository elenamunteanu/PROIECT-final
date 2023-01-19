﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using project.Data;
using project.Models;

namespace project.Pages.Angajati
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly project.Data.projectContext _context;

        public CreateModel(project.Data.projectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Angajat Angajat { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Angajat.Add(Angajat);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
