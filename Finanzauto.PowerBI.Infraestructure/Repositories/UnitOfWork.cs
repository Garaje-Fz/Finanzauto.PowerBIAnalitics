using Finanzauto.PowerBI.Application.Contracts.Persistence;
using Finanzauto.PowerBI.Domain.Common;
using Finanzauto.PowerBI.Infraestructure.Persistence;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finanzauto.PowerBI.Infraestructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private Hashtable _repositories;
        private readonly PowerBIDbContext _context;


        public UnitOfWork(PowerBIDbContext context)
        {
            _context = context;
        }

        public PowerBIDbContext NewsDbContext => _context;

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
        public IRepository<TEntity> Repository<TEntity>() where TEntity : Entity
        {
            if (_repositories == null)
                _repositories = new Hashtable();

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(Repository<>);
                var repository = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
                _repositories.Add(type, repository);
            }

            return (IRepository<TEntity>)_repositories[type];
        }
    }
}
