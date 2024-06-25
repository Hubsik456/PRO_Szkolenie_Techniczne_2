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

namespace PRO_Szkolenie_Techniczne_2_v2.Pages.Klienci
{
    public class EditModel : PageModel
    {
        private readonly Back_End.DB.DB_Context _context;

        public EditModel(Back_End.DB.DB_Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Klient Klient { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Klienci == null)
            {
                return NotFound();
            }

            var klient =  await _context.Klienci.FirstOrDefaultAsync(m => m.ID == id);
            if (klient == null)
            {
                return NotFound();
            }
            Klient = klient;
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

            _context.Attach(Klient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KlientExists(Klient.ID))
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

        private bool KlientExists(int id)
        {
          return (_context.Klienci?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
