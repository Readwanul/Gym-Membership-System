using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GYM.Controllers
{
    public class AttendenceController : ApiController
    {
        [HttpGet]
        [Route("Api/Attendence/All")]
        public HttpResponseMessage GetAllStudents()
        {
            try
            {
                var Att = BLL.Services.AttendenceService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, Att);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
        [HttpPost]
        [Route("Api/Attendence/New")]
        public HttpResponseMessage Create(AttendenceDTO dTO)
        {
            try
            {
                var Att = BLL.Services.AttendenceService.Create(dTO);
                return Request.CreateResponse(HttpStatusCode.Created, Att);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
