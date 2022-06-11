using System.ComponentModel.DataAnnotations;

namespace ICT_TRMS.Models
{
    public class StudentMarks
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }

        public int Mark  { get; set; }
        public String Grade  {
            get
            {
                if (Mark > 85) return "A";
                else if (Mark > 80) return "B+";
                else if (Mark > 75) return "B";
                else if (Mark > 70) return "C+";
                else if (Mark > 65) return "D+";
                else if (Mark > 60) return "D";
                else if (Mark > 50) return "E";
                else return "F";
            }
        }

        public Subject? Subject { get; set; }
        public Student? Student { get; set; }

    }
}
