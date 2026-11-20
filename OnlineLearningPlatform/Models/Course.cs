using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.Models
{
    internal class Course
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string? Description { get; set; }
        public decimal Price { get; set; }
        public CourseLevel Level { get; set; }
        public bool IsPublished { get; set; }
        public DateTime? PublishedDate { get; set; }

        public int InstructorID {  get; set; }
        public Instructor Instructor { get; set; } = null!;

        public int CategoryID {  get; set; }
        public Category Category { get; set; } = null!;


        public ICollection<Enrollment> Enrollments = new List<Enrollment>();

    }
}
