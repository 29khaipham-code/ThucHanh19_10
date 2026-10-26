using System.ComponentModel.DataAnnotations.Schema;

namespace ThucHanh19_10.Models
{
    public class Course
    {
        public Course()
        {
            Enrollments = new HashSet<Enrollment>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseID { set; get; }
        public string Title { set; get; }
        public int Credits { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
