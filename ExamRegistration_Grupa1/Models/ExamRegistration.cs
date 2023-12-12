namespace ExamRegistration_Grupa1.Models
{
    public class ExamRegistration
    {
        public Guid ExamRegistrationId { get; set; }

        #region Student
        public Guid StudentId { get; set; }
        public string StudentIndex { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
        public int StudentEnrolledYear { get; set; }
        #endregion

        #region Subject
        public Guid SubjectId { get; set; }
        public string SubjectCode { get; set; }
        public string SubjectName { get; set; }
        public int SubjectSemester { get; set; }
        public DateTime SubjectExamTime { get; set; }
        #endregion
    }
}
