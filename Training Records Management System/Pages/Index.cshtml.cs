using ICT_TRMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Training_Records_Management_System.Data;

namespace Training_Records_Management_System.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly ProjectContext _context;


        public IndexModel(ProjectContext context, ILogger<IndexModel> logger)
        {
            _logger = logger;
            _context = context;
        }

        public IList<Subject> Subject { get; set; } = default!;

        public IList<Student> Student { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Subject != null)
            {
                Subject = await _context.Subject.ToListAsync();
            }

            if (_context.Student != null)
            {
                Student = await _context.Student.ToListAsync();
            }
        }

        public JsonResult GetPiechartJSON()
        {
            string[] subjectArray = new string[Subject.Count];
            for (int i = 0; i < Subject.Count; i++)
            {
                subjectArray[i] = Subject[i].Title;
            }
            ChartData[] chartdataArray = new ChartData[Student.Count];
            for (int j = 0; j < Student.Count; j++)
            {
                var student = Student[j];
                ChartData chartData = new ChartData();
                chartData.name = student.FileNumber.ToString();
                if (student.Marks != null)
                {
                    int[] marks = new int[student.Marks.Count];
                    for(int i = 0; i < student.Marks.Count; i++)
                    {
                        marks[i] = student.Marks.ElementAt(i).Mark;
                    }
                    chartData.marks = marks;

                }
                chartdataArray[j] = chartData;

            }

            Charts list = new Charts();
            list.subjects = subjectArray;
            list.chartDatas = chartdataArray;


            return new JsonResult(list);
        }

    }
}