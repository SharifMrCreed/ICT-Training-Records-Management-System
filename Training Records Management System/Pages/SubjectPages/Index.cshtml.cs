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
        private readonly Training_Records_Management_System.Data.ProjectContext _context;

        public IndexModel(Training_Records_Management_System.Data.ProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Subject Sub { get; set; } = default!;

        public IList<Subject> Subject { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Subject != null)
            {
                Subject = await _context.Subject.ToListAsync();
            }
        }

        public async Task<IActionResult> OnPostCreateAsync()
        {
            if (!ModelState.IsValid || _context.Subject == null || Sub == null)
            {
                return Page();
            }

            _context.Subject.Add(Sub);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public async void OnPostLoad(int id)
        {
            if (_context.Subject != null)
            {
                var s = await _context.Subject.FirstOrDefaultAsync(m => m.ID == id);
                if (s != null)
                {
                    Sub = s;
                }
            }
        }


        public async Task<IActionResult> OnPostEditAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Sub).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubjectExists(id))
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

        private bool SubjectExists(int id)
        {
            return (_context.Subject?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
