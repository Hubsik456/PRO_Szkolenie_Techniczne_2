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

namespace PRO_Szkolenie_Techniczne_2_v2.Pages.Zamowienia
{
    public class EditModel : PageModel
    {
        private readonly Back_End.DB.DB_Context _context;

        public EditModel(Back_End.DB.DB_Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Zamowienie Zamowienie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Zamowienia == null)
            {
                return NotFound();
            }

            var zamowienie =  await _context.Zamowienia.FirstOrDefaultAsync(m => m.ID == id);
            if (zamowienie == null)
            {
                return NotFound();
            }
            Zamowienie = zamowienie;
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

            _context.Attach(Zamowienie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZamowienieExists(Zamowienie.ID))
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

        private bool ZamowienieExists(int id)
        {
          return (_context.Zamowienia?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
