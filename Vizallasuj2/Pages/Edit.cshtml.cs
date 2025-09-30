using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vizallasuj2.Data;
using Vizallasuj2.Models;

namespace Vizallasuj2.Pages
{
    public class EditModel : PageModel
    {
        private readonly Vizallasuj2.Data.vizDbContext _context;

        public EditModel(Vizallasuj2.Data.vizDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Víz Víz { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var víz =  await _context.Vízállás.FirstOrDefaultAsync(m => m.id == id);
            if (víz == null)
            {
                return NotFound();
            }
            Víz = víz;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Víz).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VízExists(Víz.id))
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

        private bool VízExists(int id)
        {
            return _context.Vízállás.Any(e => e.id == id);
        }
    }
}
