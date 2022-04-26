using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hospital.Controllers
{

    [ApiController]
    public class PatientController : Controller
    {
        MyDbContext dbContext = new MyDbContext();
        [HttpPost]
        [Route("patient/register")]
        public IActionResult Index(PatientRegister patientRegister)
        {
            var register = new PatientRegister();
            register.Firstname = patientRegister.Firstname;
            register.Lastname = patientRegister.Lastname;
            register.Email = patientRegister.Email;
            register.Phonenumber = patientRegister.Phonenumber;
            register.Address = patientRegister.Address;
            register.Password = patientRegister.Password;

            dbContext.PatientRegisters.Add(register);
            dbContext.SaveChanges();
            return Ok();
        }


        [Route("patient/verifypatient")]
        [HttpPost]
        public ActionResult VerifyUser(PatientRegister patientRegister)
        {
            var verifiedPatient = new PatientRegister();
            var res = dbContext.PatientRegisters.ToList();
            var verified = false;


            foreach (var patient in res)
            {
                if (patient.Email == patientRegister.Email && patient.Password == patientRegister.Password)
                {
                    verifiedPatient = patient;
                    verified = true;
                    break;
                }
                else
                {
                    verified = false;
                }
            }

            if (verified)
                return Ok(verifiedPatient);
            else
                return BadRequest();
        }


        [Route("patient/bookappointment")]
        [HttpPost]
        public IActionResult BookAppointment(BookAppointment bookAppointment)
        {
            var book = new BookAppointment();
            book.AppintmentId = bookAppointment.AppintmentId;
            book.Service = bookAppointment.Service;
            book.AppointmentDate = bookAppointment.AppointmentDate;
            book.AppoinmentTime = bookAppointment.AppoinmentTime;
            book.AppointmentMesaage = bookAppointment.AppointmentMesaage;

            dbContext.BookAppointments.Add(book);
            dbContext.SaveChanges();
            return Ok();

        }


        [Route("admin/remove/{id}")]
        [HttpDelete]
        public ActionResult CancelAppointment(int id)
        {
            var res = dbContext.BookAppointments.Where(item => item.AppintmentId == id).FirstOrDefault();
            if (res != null)
            {
                dbContext.BookAppointments.Remove(res);
                dbContext.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }



        [HttpGet]
        [Route("patient/Alldetails")]
        public async Task<ActionResult<IEnumerable<PatientRegister>>> GetUsers()
        {
            return await dbContext.PatientRegisters.ToListAsync();
        }

        [HttpGet]
        [Route("patient/Getappointment")]
        public async Task<ActionResult<IEnumerable<BookAppointment>>> GetAppointment()
        {
            return await dbContext.BookAppointments.ToListAsync();
        }

        //[HttpGet]
        //[Route("patient/Getsingleappointment/{id}")]
        //public async Task<ActionResult<IEnumerable<BookAppointment>>> GetSingleAppointment()
        //{
        //    return await dbContext.BookAppointments.ToListAsync();
        //}



        [HttpGet]
        [Route("patient/getreport/{id}")]

        public ActionResult AppointmentDetails(int id)
        {

            List<ReportGeneration> res = new List<ReportGeneration>();

            var data = dbContext.ReportGenerations.ToList();

            foreach (var item in data)
            {
                if (item.ReportId == id)
                    res.Add(item);
            }
            return Ok(res);
        }

        [HttpGet]
        [Route("patient/appdetails/{id}")]

        public ActionResult appointmentDetails(int id)
        {

            List<BookAppointment> res = new List<BookAppointment>();

            var data = dbContext.BookAppointments.ToList();

            foreach (var item in data)
            {
                if (item.AppintmentId == id)
                    res.Add(item);
            }
            return Ok(res);
        }
    }
}
