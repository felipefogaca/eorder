using eOrder.Domain.Common.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eOrder.Infra
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly AppDbContext _appDbContext;

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task Commit(CancellationToken cancellationToken)
        {
            return _appDbContext.SaveChangesAsync(cancellationToken);
        }

        public Task RollBack(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
