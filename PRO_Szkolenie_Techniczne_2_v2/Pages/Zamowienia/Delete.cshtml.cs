﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Back_End.DB;
using Back_End.Tabele;

namespace PRO_Szkolenie_Techniczne_2_v2.Pages.Zamowienia
{
    public class DeleteModel : PageModel
    {
        private readonly Back_End.DB.DB_Context _context;

        public DeleteModel(Back_End.DB.DB_Context context)
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

            var zamowienie = await _context.Zamowienia.FirstOrDefaultAsync(m => m.ID == id);

            if (zamowienie == null)
            {
                return NotFound();
            }
            else 
            {
                Zamowienie = zamowienie;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Zamowienia == null)
            {
                return NotFound();
            }
            var zamowienie = await _context.Zamowienia.FindAsync(id);

            if (zamowienie != null)
            {
                Zamowienie = zamowienie;
                _context.Zamowienia.Remove(Zamowienie);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
