using System.Threading.Tasks;
using DataAccess.Interfaces;
using Entities;

namespace DataAccess.UnitOfWork
{
    public interface IUow
    {
        IRepository<T> GetRepository<T>() where T : BaseEntity;

        Task SaveChangesAsync();
    }
}