using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ICT_TRMS.Models;
using Training_Records_Management_System.Data;

namespace Training_Records_Management_System.Pages.MarksPages
{
    public class EditModel : PageModel
    {
        private readonly Training_Records_Management_System.Data.ProjectContext _context;

        public EditModel(Training_Records_Management_System.Data.ProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public StudentMarks StudentMarks { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.StudentMarks == null)
            {
                return NotFound();
            }

            var studentmarks =  await _context.StudentMarks.FirstOrDefaultAsync(m => m.Id == id);
            if (studentmarks == null)
            {
                return NotFound();
            }
            StudentMarks = studentmarks;

            var student = await _context.Student.FirstOrDefaultAsync(m => m.Id == StudentMarks.StudentId);
            if (student != null) StudentMarks.Student = student;

            var subject = await _context.Subject.FirstOrDefaultAsync(m => m.ID == StudentMarks.SubjectId);
            if (subject != null) StudentMarks.Subject = subject;

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

            _context.Attach(StudentMarks).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentMarksExists(StudentMarks.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Redirect("/StudentPages/Details?id=" + StudentMarks.StudentId);
        }

        public async Task<IActionResult> OnPostDelete(int? id)
        {
            if (id == null || _context.StudentMarks == null)
            {
                return NotFound();
            }
            var studentmarks = await _context.StudentMarks.FindAsync(id);

            if (studentmarks != null)
            {
                StudentMarks = studentmarks;
                _context.StudentMarks.Remove(StudentMarks);
                await _context.SaveChangesAsync();
            }

            return Redirect("/StudentPages/Details?id="+studentmarks.StudentId);
        }

        private bool StudentMarksExists(int id)
        {
          return (_context.StudentMarks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
