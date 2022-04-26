using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hospital.Controllers
{

    [ApiController]
    public class DoctorController : Controller
    {
        MyDbContext dbContext = new MyDbContext();
        [HttpPost]
        [Route("doctor/login")]
        public IActionResult Register(DoctorLogin login)
        {
            var status = false;
            var res = dbContext.DoctorLogins.ToList();

            foreach (var item in res)

            {
                if (item.Email.Equals(login.Email) && item.Password.Equals(login.Password))

                {
                    status = true;
                }
                else
                {

                    status = false;
                }
            }

            if (status)
            {
                return Ok();
            }
            else
            {

                return Unauthorized();

            }
        }


        [HttpPost]
        [Route("generate/report")]

        public IActionResult GenerateReport(ReportGeneration reportGeneration)
        {
            var report = new ReportGeneration();
            report.ReportId = reportGeneration.ReportId;
            report.Service = reportGeneration.Service;
            report.AppointmentDate = reportGeneration.AppointmentDate;
            report.PatientDetails = reportGeneration.PatientDetails;
            report.TreatmentDetails = reportGeneration.TreatmentDetails;
            report.Recommendation= reportGeneration.Recommendation;
         

            dbContext.ReportGenerations.Add(report);
            dbContext.SaveChanges();
            return Ok();



        }
        //[HttpGet]
        //[Route("patient/getreport/{id}")]
        //public async Task<ActionResult<IEnumerable<ReportGeneration>>> GetUsers()
        //{
        //    return await dbContext.ReportGenerations.ToListAsync();
        //}

    }
}
