using AutoMapper;
using BLL.DTO;
using DAL.Table;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PlanService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Plan, PlanDTO>();
                cfg.CreateMap<PlanDTO, Plan>();
            });
            return new Mapper(config);
        }
        public static List<PlanDTO> Get()
        {
            var data = DataAccessFactory.PlanData().GetAll();
            return GetMapper().Map<List<PlanDTO>>(data);
        }
        public static PlanDTO GetByID(int id)
        {
            var data = DataAccessFactory.PlanData().GetById(id);
            if (data == null) return null;
            var cfg = new AutoMapper.MapperConfiguration(c =>
            {
                c.CreateMap<Plan, PlanDTO>();
            });
            var mapper = cfg.CreateMapper();
            var result = mapper.Map<PlanDTO>(data);
            return result;
        }
        public static PlanDTO create(PlanDTO dTO)
        {
            var Entity = GetMapper().Map<Plan>(dTO);
            var SVEntity = DataAccessFactory.PlanData().Add(Entity);
            return GetMapper().Map<PlanDTO>(SVEntity);
        }
        public static PlanDTO GetPlanDTO(int id)
        {
            var data = DataAccessFactory.PlanData().GetById(id);
            if (data == null) return null;
            return GetMapper().Map<PlanDTO>(data);
        }
        public static PlanDTO Update(PlanDTO dTO)
        {
            var entity = GetMapper().Map<Plan>(dTO);
            var updatedEntity = DataAccessFactory.PlanData().Update(entity);
            return GetMapper().Map<PlanDTO>(updatedEntity);
        }
    }
}
