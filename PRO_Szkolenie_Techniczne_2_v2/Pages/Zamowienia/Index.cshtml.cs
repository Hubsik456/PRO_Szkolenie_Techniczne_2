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
    public class IndexModel : PageModel
    {
        private readonly Back_End.DB.DB_Context _context;

        public IndexModel(Back_End.DB.DB_Context context)
        {
            _context = context;
        }

        public IList<Zamowienie> Zamowienie { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Zamowienia != null)
            {
                Zamowienie = await _context.Zamowienia.ToListAsync();
            }
        }
    }
}
