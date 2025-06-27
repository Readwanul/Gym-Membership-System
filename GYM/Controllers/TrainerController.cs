using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GYM.Controllers
{
    public class TrainerController : ApiController
    {
        [HttpGet]
        [Route("Api/Trainer/All")]
        public HttpResponseMessage GetAllStudents()
        {
            try
            {
                var Trainer = BLL.Services.TrainerService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, Trainer);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
        [HttpPost]
        [Route("Api/Trainer/New")]
        public HttpResponseMessage Ccreate(TrainerDTO dTO)
        {
            try
            {
                var course = BLL.Services.TrainerService.create(dTO);
                return Request.CreateResponse(HttpStatusCode.Created, course);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
