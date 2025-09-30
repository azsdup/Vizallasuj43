using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Vizallasuj2.Data;
using Vizallasuj2.Models;

namespace Vizallasuj2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Vizallasuj2.Data.vizDbContext _context;

        public IndexModel(Vizallasuj2.Data.vizDbContext context)
        {
            _context = context;
        }

        public IList<Víz> Víz { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Víz = await _context.Vízállás.ToListAsync();
        }
    }
}
