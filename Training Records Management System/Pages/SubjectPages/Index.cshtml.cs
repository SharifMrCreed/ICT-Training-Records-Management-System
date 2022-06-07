using System;
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
        private readonly ProjectContext _context;

        public IndexModel(ProjectContext context)
        {
            _context = context;
        }

        public IList<Subject> Subject { get;set; } = default!;

        public Subject Subj { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Subject != null)
            {
                Subject = await _context.Subject.ToListAsync();
            }
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Subject == null)
            {
                return NotFound();
            }
            var subject = await _context.Subject.FindAsync(id);

            if (subject != null)
            {
                Subj = subject;
                _context.Subject.Remove(Subj);
                await _context.SaveChangesAsync();
            }

            return Page();
        }

        public async Task<JsonResult?> OnGetSubjectAsJsonAsync(int id)
        {

            if (_context.Subject != null)
            {
                return new JsonResult(await _context.Subject.FindAsync(id));
            }
            else
            {
                return null;
            }
        }
    }
}
