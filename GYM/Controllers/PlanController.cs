using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GYM.Controllers
{
    public class PlanController : ApiController
    {
        [HttpGet]
        [Route("Api/Plan/All")]
        public HttpResponseMessage GetAllStudents()
        {
            try
            {
                var Trainer = BLL.Services.PlanService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, Trainer);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
        [HttpPost]
        [Route("Api/Plan/New")]
        public HttpResponseMessage Create(PlanDTO dTO)
        {
            try
            {
                var course = BLL.Services.PlanService.create(dTO);
                return Request.CreateResponse(HttpStatusCode.Created, course);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
        [HttpPost]
        [Route("Api/Plan/GetById")]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                var plan = BLL.Services.PlanService.GetPlanDTO(id);
                if (plan == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Plan not found");
                }
                return Request.CreateResponse(HttpStatusCode.OK, plan);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
        [HttpPut]
        [Route("Api/Plan/Update")]
        public HttpResponseMessage Update(PlanDTO dTO)
        {
            try
            {
                var updatedPlan = BLL.Services.PlanService.Update(dTO);
                if (updatedPlan == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Plan not found for update");
                }
                return Request.CreateResponse(HttpStatusCode.OK, updatedPlan);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
