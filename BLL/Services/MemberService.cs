using BLL.DTO;
using DAL.Table;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class MemberService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Member, MemberDTO>();
                cfg.CreateMap<MemberDTO, Member>();
            });
            return new Mapper(config);
        }
        public static List<MemberDTO> Get()
        {
            var data = DAL.DataAccessFactory.MemberData().GetAll();
            return GetMapper().Map<List<MemberDTO>>(data);
        }
        public static MemberDTO GetByID(int id)
        {
            var data = DAL.DataAccessFactory.MemberData().GetById(id);
            if (data == null) return null;
            var cfg = new AutoMapper.MapperConfiguration(c =>
            {
                c.CreateMap<Member, MemberDTO>();
            });
            var mapper = cfg.CreateMapper();
            var result = mapper.Map<MemberDTO>(data);
            return result;
        }
        public static MemberDTO Create(MemberDTO dTO)
        {
            var entity = GetMapper().Map<Member>(dTO);
            entity.JoinedAt = DateTime.Now; 
            var svEntity = DAL.DataAccessFactory.MemberData().Add(entity);
            SendWelcomeEmail(svEntity.Email, svEntity.Name);
            return GetMapper().Map<MemberDTO>(svEntity);
        }
        public static bool Delete(int id)
        {
            var entity = DAL.DataAccessFactory.MemberData().GetById(id);
            if (entity == null) return false;
            var result = DAL.DataAccessFactory.MemberData().Delete(id);
            return result != null;
        }
        private static void SendWelcomeEmail(string toEmail, string memberName)
        {
            var subject = "Welcome to the Gym!";
            var body = $"Hello {memberName},<br/>Welcome to our gym! We're excited to have you with us.";
            var emailService = new EmailService();
            emailService.SendEmail(toEmail, subject, body);
        }

    }
}
