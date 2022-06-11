using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ICT_TRMS.Models;
using Training_Records_Management_System.Data;
using Microsoft.EntityFrameworkCore;

namespace Training_Records_Management_System.Pages.MarksPages
{
    public class CreateModel : PageModel
    {
        private readonly ProjectContext _context;

        public CreateModel(ProjectContext context)
        {
            _context = context;
        }
        public List<SelectListItem> Options { get; set; }

        [BindProperty]
        public StudentMarks StudentMarks { get; set; } = default!;

        public Student Student { get; set; } = default!;

        public async Task<IActionResult> OnGet(int? id)
        {
            if (id == null || _context.Student == null)
            {
                return NotFound();
            }
            var student = await _context.Student.FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            else
            {
                Student = student;
            }
            if (_context.Subject == null)
            {
                return NotFound();

            }
            Options = _context.Subject.Select(a =>
                                  new SelectListItem
                                  {
                                      Value = a.ID.ToString(),
                                      Text = a.Title
                                  }).ToList();

            return Page();
        }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.StudentMarks == null || StudentMarks == null)
            {
                return Page();
            }
            _context.StudentMarks.Add(StudentMarks);
            await _context.SaveChangesAsync();

            return Redirect("/StudentPages/Details?id="+StudentMarks.StudentId );
        }
    }
}
