using System;
using Microsoft.EntityFrameworkCore;

namespace ShipmentPackerDAL
{
    public interface IUnitOfWork : IDisposable
    {
        IProjectRepository ProjectRepository { get; }

        IPackingListRepository PackingListRepository { get; }

        IColliListRepository ColliListRepository { get; }

        IItemRepository ItemRepository { get; }

        IPackItemRepository PackItemRepository { get; }

        IColliItemRepository ColliItemRepository { get; }

        IFreightConditionRepository FreightConditionRepository { get; }

        int Complete();

        void clearDb();
    }
}
