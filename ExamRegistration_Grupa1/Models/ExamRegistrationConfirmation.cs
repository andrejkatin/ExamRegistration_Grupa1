namespace ExamRegistration_Grupa1.Models
{
    public class ExamRegistrationConfirmation
    {
        public Guid ExamRegistrationId { get; set; }
        public string StudentFirstName { get; set; }
        public string StudentLastName { get; set; }
        public string StudentIndex { get; set; }
        public string SubjectName { get; set; }
        public DateTime SubjectExamTime { get; set; }
    }
}
