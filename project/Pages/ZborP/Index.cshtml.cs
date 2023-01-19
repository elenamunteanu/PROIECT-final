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
    public class IndexModel : PageModel
    {
        private readonly project.Data.projectContext _context;

        public IndexModel(project.Data.projectContext context)
        {
            _context = context;
        }

        public IList<Plecari> Plecari { get;set; } = default!;
        public SelectList Comp;
        public string CurrentFilter { get; set; }


        public async Task OnGetAsync(string compaer, string searchString)
        {
            IQueryable<string> genreQuery = from m in _context.Plecari
                                            orderby m.Companie.DenumireCompanie
                                            select m.Companie.DenumireCompanie;

            //CurrentFilter = searchString;

            var zboruriP = from m in _context.Plecari
                           select m;



            if (!String.IsNullOrEmpty(searchString))
            {
                zboruriP = zboruriP.Where(s => s.Destinatie.DenumireOras.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(compaer))
            {
                zboruriP = zboruriP.Where(x => x.Companie.DenumireCompanie == compaer);
            }
            Comp = new SelectList(await genreQuery.Distinct().ToListAsync());
            Plecari = await zboruriP.Include(b => b.Destinatie).Include(b => b.Companie).ToListAsync();

            //if (_context.Plecari != null)
            //{
            //    Plecari = await _context.Plecari.Include(b=>b.Destinatie).Include(b=>b.Companie).ToListAsync();
            //}
        }
    }
}
