using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Vizallasuj2.Data;
using Vizallasuj2.Models;

namespace Vizallasuj2.Pages
{
    public class CreateModel : PageModel
    {
        private readonly Vizallasuj2.Data.vizDbContext _context;

        public CreateModel(Vizallasuj2.Data.vizDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Víz Víz { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Vízállás.Add(Víz);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
