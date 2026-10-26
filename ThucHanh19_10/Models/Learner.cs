namespace ThucHanh19_10.Models
{
    public class Learner
    {
        public int LearnerID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public int MajorID { set; get; }
        public virtual Major? Major { set; get; }
        public virtual ICollection<Enrollment>? Enrollments { get; set; }
    }
}
