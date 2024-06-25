using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Back_End.DB;
using Back_End.Tabele;

namespace PRO_Szkolenie_Techniczne_2_v2.Pages.Samochody
{
    public class DeleteModel : PageModel
    {
        private readonly Back_End.DB.DB_Context _context;

        public DeleteModel(Back_End.DB.DB_Context context)
        {
            _context = context;
        }

        [BindProperty]
      public Samochod Samochod { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Samochody == null)
            {
                return NotFound();
            }

            var samochod = await _context.Samochody.FirstOrDefaultAsync(m => m.ID == id);

            if (samochod == null)
            {
                return NotFound();
            }
            else 
            {
                Samochod = samochod;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Samochody == null)
            {
                return NotFound();
            }
            var samochod = await _context.Samochody.FindAsync(id);

            if (samochod != null)
            {
                Samochod = samochod;
                _context.Samochody.Remove(Samochod);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
