using System.ComponentModel.DataAnnotations;

namespace ICT_TRMS.Models
{
    public class StudentMarks
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }

        public int Mark  { get; set; }

        public Subject Subject { get; set; }
        public Student Student { get; set; }


    }
}
