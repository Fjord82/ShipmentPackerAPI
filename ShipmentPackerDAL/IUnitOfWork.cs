using System;
using Microsoft.EntityFrameworkCore;

namespace ShipmentPackerDAL
{
    public interface IUnitOfWork : IDisposable
    {
        IProjectRepository ProjectRepository { get; }

        IPackingListRepository PackingListRepository { get; }

        int Complete();

        void clearDb();
    }
}
