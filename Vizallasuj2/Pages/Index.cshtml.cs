using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Vizallasuj2.Data;
using Vizallasuj2.Models;

namespace vizallas.Pages
{
    public class IndexModel : PageModel
    {
        private readonly vizDbContext _context;
        public IndexModel(vizDbContext context) => _context = context;

        [BindProperty(SupportsGet = true)]
        public string? FolyoParam { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? VarosParam { get; set; }

        public List<string> Folyo { get; set; } = new();

        public List<string> Varos { get; set; } = new();
        [BindProperty(SupportsGet = true)]
        public IList<Vizállás> VizallasLista { get; set; } = new List<Vizállás>();

        public async Task OnGetAsync()
        {
            Folyo = await _context.Vízállás
                .Select(x => x.Folyo)
                .Distinct()
                .OrderBy(x => x)
                .ToListAsync();

            Varos = await _context.Vízállás
                .Select(x => x.Varos)
                .Distinct()
                .OrderBy(x => x)
                .ToListAsync();

            var q = _context.Vízállás.AsQueryable();

            if (!string.IsNullOrWhiteSpace(FolyoParam))
                q = q.Where(x => x.Folyo == FolyoParam);

            if (!string.IsNullOrWhiteSpace(VarosParam))
                q = q.Where(x => x.Varos == VarosParam);

            VizallasLista = await q
                .OrderBy(x => x.Varos)
                .ThenBy(x => x.Datum)
                .ToListAsync();
        }
    }
}