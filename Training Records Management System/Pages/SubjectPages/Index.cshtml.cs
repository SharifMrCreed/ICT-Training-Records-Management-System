﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ICT_TRMS.Models;
using Training_Records_Management_System.Data;

namespace Training_Records_Management_System.Pages.SubjectPages
{
    public class IndexModel : PageModel
    {
        private readonly Training_Records_Management_System.Data.ProjectContext _context;

        public IndexModel(Training_Records_Management_System.Data.ProjectContext context)
        {
            _context = context;
        }

        public IList<Subject> Subject { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Subject != null)
            {
                Subject = await _context.Subject.ToListAsync();
            }
        }
    }
}
