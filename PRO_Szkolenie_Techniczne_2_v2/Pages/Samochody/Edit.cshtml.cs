using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Back_End.DB;
using Back_End.Tabele;

namespace PRO_Szkolenie_Techniczne_2_v2.Pages.Samochody
{
    public class EditModel : PageModel
    {
        private readonly Back_End.DB.DB_Context _context;

        public EditModel(Back_End.DB.DB_Context context)
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

            var samochod =  await _context.Samochody.FirstOrDefaultAsync(m => m.ID == id);
            if (samochod == null)
            {
                return NotFound();
            }
            Samochod = samochod;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Samochod).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SamochodExists(Samochod.ID))
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

        private bool SamochodExists(int id)
        {
          return (_context.Samochody?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
