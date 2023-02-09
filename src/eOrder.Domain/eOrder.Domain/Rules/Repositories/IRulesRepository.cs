using eOrder.Domain.Common.SeedWork;
using eOrder.Domain.Common.SeedWork.SearchableRepository;
using eOrder.Domain.Rules.Entity;

namespace eOrder.Domain.Rules.Repositories
{
    public interface IRulesRepository : IGenericRepository<Rule>, ISearchableRepository<Rule>
    {
        Task<List<Rule>> FindAllActivitiesWithNoParameters(CancellationToken cancellationToken);
        Task<Rule?> FindByIndex(int index, CancellationToken cancellationToken);
        Task<List<Rule>> FindAll(CancellationToken cancellationToken);

    }
}
