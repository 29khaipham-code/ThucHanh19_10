namespace ThucHanh19_10.Models
{
    public class Enrollment
    {
        public int EnrollmentID { set; get; }
        public int CourseID { set; get; }
        public int LearnerID { set; get; }
        public float Grade { set; get; }
        public virtual Learner? Learner { get; set; }

        public virtual Course? Course { get; set; }

    }
}
