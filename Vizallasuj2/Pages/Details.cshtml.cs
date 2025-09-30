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
    public class DetailsModel : PageModel
    {
        private readonly Vizallasuj2.Data.vizDbContext _context;

        public DetailsModel(Vizallasuj2.Data.vizDbContext context)
        {
            _context = context;
        }

        public Víz Víz { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var víz = await _context.Vízállás.FirstOrDefaultAsync(m => m.id == id);
            if (víz == null)
            {
                return NotFound();
            }
            else
            {
                Víz = víz;
            }
            return Page();
        }
    }
}
