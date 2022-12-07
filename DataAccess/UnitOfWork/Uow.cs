using System.Threading.Tasks;
using DataAccess.Contexts;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using Entities;

namespace DataAccess.UnitOfWork
{
    public class Uow : IUow
    {
        private readonly AdvertisementAppContext _context;

        public Uow(AdvertisementAppContext context)
        {
            _context = context;
        }
        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return new Repository<T>(_context);
        } 
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}