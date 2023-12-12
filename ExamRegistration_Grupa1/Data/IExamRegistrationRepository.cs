using ExamRegistration_Grupa1.Models;

namespace ExamRegistration_Grupa1.Data
{
    public interface IExamRegistrationRepository
    {
        List<ExamRegistration> GetExamRegistrations();
        ExamRegistration GetExamRegistrationById(Guid id);
        ExamRegistrationConfirmation CreateExamRegistration(ExamRegistration exam);
        ExamRegistrationConfirmation UpdateExamRegistration(ExamRegistration exam);
        void DeleteExamRegistration(Guid id);
    }
}
