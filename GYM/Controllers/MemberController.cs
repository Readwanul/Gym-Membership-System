using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GYM.Controllers
{
    public class MemberController : ApiController
    {
        [HttpGet]
        [Route("Api/Member/All")]
        public HttpResponseMessage GetAllStudents()
        {
            try
            {
                var Trainer = BLL.Services.MemberService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, Trainer);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
        [HttpPost]
        [Route("Api/Member/New")]
        public HttpResponseMessage Create(MemberDTO dTO)
        {
            try
            {
                var course = BLL.Services.MemberService.Create(dTO);
                return Request.CreateResponse(HttpStatusCode.Created, course);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
        [HttpGet]
        [Route("Api/Member/GetById")]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                var plan = BLL.Services.MemberService.GetByID(id);
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
        [HttpGet]
        [Route("Api/Member/Delete")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var plan = BLL.Services.MemberService.GetByID(id);
                if (plan == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Member not found");
                }
                var Delete=BLL.Services.MemberService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, "Member deleted successfully");

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
