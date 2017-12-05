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

        int Complete();

        void clearDb();
    }
}
