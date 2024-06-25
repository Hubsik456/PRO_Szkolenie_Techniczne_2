using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Back_End.DB;
using Back_End.Tabele;

namespace PRO_Szkolenie_Techniczne_2_v2.Pages.Klienci
{
    public class CreateModel : PageModel
    {
        private readonly Back_End.DB.DB_Context _context;

        public CreateModel(Back_End.DB.DB_Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Klient Klient { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Klienci == null || Klient == null)
            {
                return Page();
            }

            _context.Klienci.Add(Klient);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
