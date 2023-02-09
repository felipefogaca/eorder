using eOrder.Domain.Common.SeedWork;
using eOrder.Domain.DayOffs.Entities;

namespace eOrder.Domain.DayOffs.Repositories
{
    public interface IDayOffsRepository : IGenericRepository<DayOff>
    {
        Task<List<DayOff>> Search(DateTime startDate, DateTime endDate, CancellationToken cancellationToken);
    }
}
