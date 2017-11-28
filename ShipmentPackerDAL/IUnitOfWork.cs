using System;
namespace ShipmentPackerDAL
{
    public interface IUnitOfWork : IDisposable
    {
        IProjectRepository ProjectRepository { get; }

        int Complete();
    }
}
