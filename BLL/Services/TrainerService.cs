using AutoMapper;
using DAL;
using DAL.Table;
using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class TrainerService
    {
        public static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Trainer, TrainerDTO>();
                cfg.CreateMap<TrainerDTO, Trainer>();
            });
            return new Mapper(config);
        }
        public static List<TrainerDTO> Get()
        {
            var data = DataAccessFactory.TrainerData().GetAll();
            return GetMapper().Map<List<TrainerDTO>>(data);
        }
        public static TrainerDTO Get(int id)
        {
            var data = DataAccessFactory.TrainerData().GetById(id);
            if (data == null) return null;
            var cfg = new AutoMapper.MapperConfiguration(c =>
            {
                c.CreateMap<Trainer, TrainerDTO>();
            });
            var mapper = cfg.CreateMapper();
            var result = mapper.Map<TrainerDTO>(data);
            return result;
        }
        public static TrainerDTO create(TrainerDTO dTO)
        {
            var Entity = GetMapper().Map<Trainer>(dTO);
            var SVEntity = DataAccessFactory.TrainerData().Add(Entity);
            return GetMapper().Map<TrainerDTO>(SVEntity);
        }
    }
}
