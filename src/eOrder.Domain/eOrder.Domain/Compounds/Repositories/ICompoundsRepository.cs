using eOrder.Domain.Common.SeedWork;
using eOrder.Domain.Compounds.Entities;

namespace eOrder.Domain.Compounds.Repositories
{
    public interface ICompoundsRepository : IGenericRepository<Compound>
    {
        Task<Compound> FindByCode(string code, CancellationToken cancellationToken);
    }
}
