using AutoMapper;
using BLL.DTO;
using DAL;
using DAL.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class AttendenceService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Attendence, AttendenceDTO>();
                cfg.CreateMap<AttendenceDTO, Attendence>();
            });
            return new Mapper(config);
        }
        public static List<AttendenceDTO> Get()
        {
            var data = DataAccessFactory.AttendanceData().GetAll();
            return GetMapper().Map<List<AttendenceDTO>>(data);
        }
        public static AttendenceDTO Create(AttendenceDTO dTO)
        {
            if (!validate(dTO.MemberID))
            {
                throw new Exception("Member is not eligible for attendance within the first month of joining.");
            }

            
            var entity = GetMapper().Map<Attendence>(dTO);
            entity.Attendance_date=DateTime.Now;
            var savedEntity = DataAccessFactory.AttendanceData().Add(entity);
            return GetMapper().Map<AttendenceDTO>(savedEntity);
        }

        public static bool validate(int id)
        {
            var Member = DataAccessFactory.MemberData().GetById(id);
            var DateforValidation = Member.JoinedAt.AddMonths(1);
            if (DateTime.Now <= DateforValidation)
            {
                return true; 
            }
            else
            {
                Member.Membership_status = "Inactive";
                DataAccessFactory.MemberData().Update(Member);
                return false; 
            }
        }

    }
}
