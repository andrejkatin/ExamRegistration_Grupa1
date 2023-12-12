using ExamRegistration_Grupa1.Data;
using ExamRegistration_Grupa1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace ExamRegistration_Grupa1.Controllers
{
    // Omogucava dodavanje dodatnih stvari, npr. status kodova
    [ApiController]
    [Route("api/examRegistrations")]
    public class ExamRegistrationController : Controller
    {
        private readonly IExamRegistrationRepository examRegistrationRepository;
        private readonly LinkGenerator linkGenerator; //Služi za generisanje putanje do neke akcije (videti primer u metodu CreateExamRegistration)

        //Pomoću dependency injection-a dodajemo potrebne zavisnosti
        public ExamRegistrationController(IExamRegistrationRepository examRegistrationRepository, LinkGenerator linkGenerator)
        {
            this.examRegistrationRepository = examRegistrationRepository;
            this.linkGenerator = linkGenerator;
        }

        [HttpGet]
        public ActionResult<List<ExamRegistration>> GetExamRegistrations()
        {
            List<ExamRegistration> examRegistrations = examRegistrationRepository.GetExamRegistrations();
            if (examRegistrations == null || examRegistrations.Count == 0)
            {
                NoContent();
            }
            return Ok(examRegistrations);
        }

        [HttpGet("{examRegistrationId}")]
        public ActionResult<ExamRegistration> GetExamRegistration(Guid examRegistrationId)
        {
            ExamRegistration examRegistrationModel = examRegistrationRepository.GetExamRegistrationById(examRegistrationId);
            if (examRegistrationModel == null)
            {
                return NotFound();
            }
            return Ok(examRegistrationModel);
        }

        [HttpPost]
        public ActionResult<ExamRegistrationConfirmation> CreateExamRegistration([FromBody] ExamRegistration examRegistration)
        {
            try
            {
                bool modelValid = ValidateExamRegistration(examRegistration);

                if (!modelValid)
                {
                    return BadRequest("The exam is not in the scope of the students enrolled year or current semester");
                }

                ExamRegistrationConfirmation confirmation = examRegistrationRepository.CreateExamRegistration(examRegistration);
                // Dobar API treba da vrati lokator gde se taj resurs nalazi
                string location = linkGenerator.GetPathByAction("GetExamRegistration", "ExamRegistration", new { examRegistrationId = confirmation.ExamRegistrationId });
                return Created(location, confirmation);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Create Error");
            }
        }

        [HttpDelete("{examRegistrationId}")]
        public IActionResult DeleteExamRegistration(Guid examRegistrationId)
        {
            try
            {
                ExamRegistration examRegistrationModel = examRegistrationRepository.GetExamRegistrationById(examRegistrationId);
                if (examRegistrationModel == null)
                {
                    return NotFound();
                }
                examRegistrationRepository.DeleteExamRegistration(examRegistrationId);
                // Status iz familije 2xx koji se koristi kada se ne vraca nikakav objekat, ali naglasava da je sve u redu
                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Delete Error");
            }
        }

        // Validira da student ne moze da prijavi ispit u visoj godini nego sto je prijavljen
        private bool ValidateExamRegistration(ExamRegistration examRegistration)
        {
            if (examRegistration.StudentFirstName == examRegistration.StudentLastName)
            {
                return false;
            }
            return true;
        }
    }
}
