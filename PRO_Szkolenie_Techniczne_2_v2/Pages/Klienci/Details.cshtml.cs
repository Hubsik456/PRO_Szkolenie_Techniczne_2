﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Back_End.DB;
using Back_End.Tabele;

namespace PRO_Szkolenie_Techniczne_2_v2.Pages.Klienci
{
    public class DetailsModel : PageModel
    {
        private readonly Back_End.DB.DB_Context _context;

        public DetailsModel(Back_End.DB.DB_Context context)
        {
            _context = context;
        }

      public Klient Klient { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Klienci == null)
            {
                return NotFound();
            }

            var klient = await _context.Klienci.FirstOrDefaultAsync(m => m.ID == id);
            if (klient == null)
            {
                return NotFound();
            }
            else 
            {
                Klient = klient;
            }
            return Page();
        }
    }
}
