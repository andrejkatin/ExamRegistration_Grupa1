using ExamRegistration_Grupa1.Models;

namespace ExamRegistration_Grupa1.Data
{
    public class ExamRegistrationRepository : IExamRegistrationRepository
    {
        public static List<ExamRegistration> ExamRegistrations = new List<ExamRegistration>();

        public ExamRegistrationRepository()
        {
            FillData();
        }

        private void FillData()
        {
            ExamRegistrations.AddRange(new List<ExamRegistration>
            {
                new ExamRegistration
                {
                    ExamRegistrationId = Guid.Parse("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                    StudentId = Guid.Parse("044f3de0-a9dd-4c2e-b745-89976a1b2a36"),
                    StudentFirstName = "Petar",
                    StudentLastName = "Petrović",
                    StudentIndex = "IT1/2020",
                    StudentEnrolledYear = 1,
                    SubjectId = Guid.Parse("21ad52f8-0281-4241-98b0-481566d25e4f"),
                    SubjectCode = "S12020",
                    SubjectName = "Subject 1",
                    SubjectSemester = 1,
                    SubjectExamTime = DateTime.Parse("2020-11-15T09:00:00")
                },
                new ExamRegistration
                {
                    ExamRegistrationId = Guid.Parse("1c7ea607-8ddb-493a-87fa-4bf5893e965b"),
                    StudentId = Guid.Parse("32cd906d-8bab-457c-ade2-fbc4ba523029"),
                    StudentFirstName = "Marko",
                    StudentLastName = "Marković",
                    StudentIndex = "IT2/2019",
                    StudentEnrolledYear = 2,
                    SubjectId = Guid.Parse("9d8bab08-f442-4297-8ab5-ddfe08e335f3"),
                    SubjectCode = "S22020",
                    SubjectName = "Subject 2",
                    SubjectSemester = 2,
                    SubjectExamTime = DateTime.Parse("2020-11-15T09:00:00")
                }
            });
        }

        public ExamRegistrationConfirmation CreateExamRegistration(ExamRegistration exam)
        {
            exam.ExamRegistrationId = Guid.NewGuid();
            ExamRegistrations.Add(exam);

            return new ExamRegistrationConfirmation
            {
                ExamRegistrationId = exam.ExamRegistrationId,
                StudentFirstName = exam.StudentFirstName,
                StudentLastName = exam.StudentLastName,
                StudentIndex = exam.StudentIndex,
                SubjectExamTime = exam.SubjectExamTime,
                SubjectName = exam.SubjectName
            };
        }

        public void DeleteExamRegistration(Guid id)
        {
            ExamRegistrations.Remove(GetExamRegistrationById(id));
        }

        public ExamRegistration GetExamRegistrationById(Guid id)
        {
            return ExamRegistrations.FirstOrDefault(e => e.ExamRegistrationId == id);
        }

        public List<ExamRegistration> GetExamRegistrations()
        {
            return ExamRegistrations;
        }

        public ExamRegistrationConfirmation UpdateExamRegistration(ExamRegistration exam)
        {
            throw new NotImplementedException();
        }
    }
}
