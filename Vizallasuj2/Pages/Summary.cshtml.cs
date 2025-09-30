using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Vizallasuj2.Data;

namespace Vizallasuj2.Pages
{
    public class SummaryRow
    {
        public string Varos { get; set; } = string.Empty;
        public int MinValue { get; set; }
        public DateTime MinDate { get; set; }
        public int MaxValue { get; set; }
        public DateTime MaxDate { get; set; }
    }

    public class SummaryModel : PageModel
    {
        private readonly vizDbContext _context;
        public SummaryModel(vizDbContext context) => _context = context;

        [BindProperty(SupportsGet = true)]
        public string? Folyo { get; set; }

        public List<string> Folyok { get; set; } = new();
        public List<SummaryRow> Rows { get; set; } = new();

        public async Task OnGetAsync()
        {
            Folyok = await _context.Vizállás
                .Select(x => x.Folyo)
                .Distinct()
                .OrderBy(x => x)
                .ToListAsync();

            Folyo ??= Folyok.FirstOrDefault();
            if (string.IsNullOrWhiteSpace(Folyo)) return;

            var data = await _context.Vizállás
                .Where(x => x.Folyo == Folyo)
                .ToListAsync();

            Rows = data
                .GroupBy(x => x.Varos)
                .Select(g =>
                {
                    var min = g.OrderBy(x => x.Ertek).First();
                    var max = g.OrderByDescending(x => x.Ertek).First();

                    return new SummaryRow
                    {
                        Varos = g.Key,
                        MinValue = min.Ertek,
                        MinDate = min.Datum,
                        MaxValue = max.Ertek,
                        MaxDate = max.Datum
                    };
                })
                .OrderBy(x => x.Varos)
                .ToList();
        }
    }
}