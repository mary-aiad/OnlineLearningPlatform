using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.Models
{
    internal class Instructor
    {
        public int Id { get; set; }

        public string FullName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? ShortBio { get; set; }

        public DateTime DateJoined { get; set; }

        public ICollection<Course> Courses { get; set; } = new List<Course>();
    }
}
