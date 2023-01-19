using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using project.Data;
using project.Models;

namespace project.Pages.ZborS
{
    public class IndexModel : PageModel
    {
        private readonly project.Data.projectContext _context;

        public IndexModel(project.Data.projectContext context)
        {
            _context = context;
        }

        public IList<Sosiri> Sosiri;
        public SelectList Comp;
        public string CurrentFilter { get; set; }


        public async Task OnGetAsync(string compaer, string searchString, string sortOrder)
        {
      

            IQueryable<string> genreQuery = from m in _context.Sosiri
                                            orderby m.Companie.DenumireCompanie
                                            select m.Companie.DenumireCompanie;

            //CurrentFilter = searchString;

            var zboruriS = from m in _context.Sosiri
                         select m;

         

            if (!String.IsNullOrEmpty(searchString))
            {
                zboruriS = zboruriS.Where(s => s.Destinatie.DenumireOras.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(compaer))
            {
                zboruriS = zboruriS.Where(x => x.Companie.DenumireCompanie == compaer);
            }
            Comp = new SelectList(await genreQuery.Distinct().ToListAsync());
            Sosiri = await zboruriS.Include(b => b.Destinatie).Include(b => b.Companie).ToListAsync();

           

            //if (_context.Sosiri != null)
            //{
            //      Sosiri = await _context.Sosiri.Include(b=>b.Destinatie).Include(b => b.Companie).ToListAsync();
            //}
        }

     
    }
}
