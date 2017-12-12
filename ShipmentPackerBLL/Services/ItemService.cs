using System;
using System.Collections.Generic;
using System.Linq;
using ShipmentPackerBLL.BusinessObjects;
using ShipmentPackerBLL.Converters;
using ShipmentPackerDAL;

namespace ShipmentPackerBLL.Services
{
    public class ItemService : IItemService
    {
        public IDALFacade _facade { get; set; }
        ItemConverter _conv;
        PackItemConverter _convPI;
        ColliItemConverter _convCI;
        FreightConditionConverter _convFC;

        public ItemService(IDALFacade facade)
        {
            _facade = facade;
            _conv = new ItemConverter();
            _convPI = new PackItemConverter();
            _convCI = new ColliItemConverter();
            _convFC = new FreightConditionConverter();
        }

        public ItemBO Create(ItemBO item)
        {
            if (item == null)
            {
                return null;
            }

            using(var uow = _facade.UnitOfWork)
            {
                var itemCreated = uow.ItemRepository.Create(_conv.ConvertBO(item));
                uow.Complete();
                return _conv.Convert(itemCreated);
            }
        }

        public ItemBO Delete(int Id)
        {
            if (Id < 1)
            {
                return null;
            }
            using (var uow = _facade.UnitOfWork)
            {

                var item = Get(Id);
                if (item == null)
                {
                    return null;
                }
                item = _conv.Convert(uow.ItemRepository.Delete(Id));
                uow.Complete();
                return item;
            }
        }

        public ItemBO Get(int Id)
        {
            if (Id < 1)
            {
                return null;
            }

            using (var uow = _facade.UnitOfWork)
            {
                var item = _conv.Convert(uow.ItemRepository.Get(Id));
                if(item != null)
                {
                    item.PackItems = uow.PackItemRepository.GetAllById(item.PackItemsIds)
                        .Select(pi => _convPI.Convert(pi))
                        .ToList();

                    item.ColliItems = uow.ColliItemRepository.GetAllById(item.ColliItemsIds)
                        .Select(ci => _convCI.Convert(ci))
                        .ToList();

                    item.FreightConditions = uow.FreightConditionRepository.GetAllById(item.FreightConditionIds)
                        .Select(fc => _convFC.Convert(fc))
                        .ToList();
                }

                uow.Complete();
                return item;
            }
        }

        public List<ItemBO> GetAll()
        {
            using (var uow = _facade.UnitOfWork)
            {
                return uow.ItemRepository.GetAll().Select(i => _conv.Convert(i)).ToList();
            }
        }

        public ItemBO Update(ItemBO item)
        {
            if (item == null)
                return null;

            using (var uow = _facade.UnitOfWork)
            {
                var itemEnt = uow.ItemRepository.Get(item.Id);

                if (itemEnt == null)
                    return null;

                var itemUpdated = _conv.ConvertBO(item);

                itemEnt.Id = itemUpdated.Id;
                itemEnt.ItemName = itemUpdated.ItemName;
                itemEnt.Dimension = itemUpdated.Dimension;
                itemEnt.Weight = itemUpdated.Weight;
                itemEnt.DangerousGoods = itemUpdated.DangerousGoods;

                if (itemUpdated != null)
                {
                    //Related to FreightCondition relation
                    itemEnt.FreightConditions.RemoveAll(
                        ic => !itemUpdated.FreightConditions.Exists(
                            fc => fc.FreightConditionID == ic.FreightConditionID &&
                            fc.ItemID == ic.ItemID));

                    itemUpdated.FreightConditions.RemoveAll(
                            ic => itemEnt.FreightConditions.Exists(
                                fc => fc.FreightConditionID == ic.FreightConditionID &&
                                fc.ItemID == ic.ItemID));
                   
                    itemEnt.FreightConditions.AddRange(
                        itemUpdated.FreightConditions);
                }

                uow.Complete();
                return _conv.Convert(itemEnt);
            }
        }
    }
}
