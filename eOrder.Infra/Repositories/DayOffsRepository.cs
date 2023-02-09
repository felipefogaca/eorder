using eOrder.Domain.DayOffs.Entities;
using eOrder.Domain.DayOffs.Repositories;
using Microsoft.EntityFrameworkCore;

namespace eOrder.Infra.Repositories
{
    public class DayOffsRepository : IDayOffsRepository
    {

        private readonly AppDbContext _appDbContext;

        public DayOffsRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task Delete(DayOff aggregate, CancellationToken cancellationToken)
        {
            return Task.FromResult(_appDbContext.Remove(aggregate));
        }

        public Task<DayOff?> Find(long id, CancellationToken cancellationToken)
        {
            return _appDbContext.DayOffs.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task Insert(DayOff aggregate, CancellationToken cancellationToken)
        {
            await _appDbContext.AddAsync(aggregate, cancellationToken);
        }

        public Task<List<DayOff>> Search(DateTime startDate, DateTime endDate, CancellationToken cancellationToken)
        {
            return _appDbContext
                .DayOffs
                .Where(x => x.Date >= startDate && x.Date <= endDate)
                .AsNoTracking()
                .OrderBy(x => x.Date)
                .ToListAsync(cancellationToken);
        }

        public Task Update(DayOff aggregate, CancellationToken cancellationToken)
        {
            return Task.FromResult(_appDbContext.Update(aggregate));
        }
    }
}
