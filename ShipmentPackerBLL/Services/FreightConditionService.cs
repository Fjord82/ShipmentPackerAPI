using System;
using System.Collections.Generic;
using System.Linq;
using ShipmentPackerBLL.BusinessObjects;
using ShipmentPackerBLL.Converters;
using ShipmentPackerDAL;

namespace ShipmentPackerBLL.Services
{
    public class FreightConditionService : IFreightConditionService
    {
        public IDALFacade _facade { get; set; }
        FreightConditionConverter _conv;

        public FreightConditionService(IDALFacade facade)
        {
            _facade = facade;
            _conv = new FreightConditionConverter();
        }

        public FreightConditionBO Create(FreightConditionBO condition)
        {
            if(condition == null)
            {
                return null;
            }
            using(var uow = _facade.UnitOfWork)
            {
                var createdCondition = uow.FreightConditionRepository.Create(_conv.ConvertBO(condition));
                uow.Complete();
                return _conv.Convert(createdCondition);
            }
        }

        public FreightConditionBO Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public FreightConditionBO Get(int Id)
        {
            if(Id < 1)
            {
                return null;
            }
            using(var uow = _facade.UnitOfWork)
            {
                var condition = _conv.Convert(uow.FreightConditionRepository.Get(Id));
                uow.Complete();
                return condition;
            }

        }

        public List<FreightConditionBO> GetAll()
        {
            using (var uow = _facade.UnitOfWork)
            {
                return uow.FreightConditionRepository.GetAll().Select(fc => _conv.Convert(fc)).ToList();
            }
        }

        public FreightConditionBO Update(FreightConditionBO condition)
        {
            throw new NotImplementedException();
        }
    }
}
