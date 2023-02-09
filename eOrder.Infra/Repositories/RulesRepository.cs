using eOrder.Domain.Common.SeedWork.SearchableRepository;
using eOrder.Domain.Rules.Entity;
using eOrder.Domain.Rules.Repositories;
using Microsoft.EntityFrameworkCore;

namespace eOrder.Infra.Repositories
{
    public class RulesRepository : IRulesRepository
    {

        private readonly AppDbContext _appDbContext;

        public RulesRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task Delete(Rule aggregate, CancellationToken cancellationToken)
        {
            return Task.FromResult(_appDbContext.Remove(aggregate));
        }

        public Task<Rule?> Find(long id, CancellationToken cancellationToken)
        {
            return _appDbContext
                .Rules
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.Id == id, cancellationToken);
        }

        public Task<List<Rule>> FindAllActivitiesWithNoParameters(CancellationToken cancellationToken)
        {
            return _appDbContext
                .Rules
                .Where(r => r.IsActive == true && r.ParameterType == Rule.Type.NoParameter)
                .AsNoTracking()
                .OrderBy(r => r.Index)
                .ToListAsync(cancellationToken);
        }

        public Task<Rule?> FindByIndex(int index, CancellationToken cancellationToken)
        {
            return _appDbContext
                .Rules
                .AsNoTracking()
                .FirstOrDefaultAsync(r => r.Index == index, cancellationToken);
        }

        public Task<List<Rule>> FindAll(CancellationToken cancellationToken)
        {
            return _appDbContext
                .Rules
                .AsNoTracking()
                .OrderBy(r => r.Index)
                .ToListAsync(cancellationToken);
        }

        public async Task Insert(Rule aggregate, CancellationToken cancellationToken)
        {
            await _appDbContext.Rules.AddAsync(aggregate, cancellationToken);
        }

        public Task Update(Rule aggregate, CancellationToken cancellationToken)
        {
            return Task.FromResult(_appDbContext.Update(aggregate));
        }

        public async Task<SearchOutput<Rule>> Search(SearchInput input, CancellationToken cancellationToken)
        {
            var toSkip = (input.Page - 1) * input.PerPage;
            var query = _appDbContext.Rules.AsNoTracking();

            query = AddRuleToQuery(query, input.OrderBy, input.Order);

            if (!string.IsNullOrEmpty(input.Search))
            {
                query = query.Where(x => x.Name.Contains(input.Search));
            }

            var items = await query
                .Skip(toSkip)
                .Take(input.PerPage)
                .ToListAsync(cancellationToken);

            var count = await query.CountAsync(cancellationToken);

            return new SearchOutput<Rule>(
                input.Page,
                input.PerPage,
                count,
                items);
        }

        private static IQueryable<Rule> AddRuleToQuery(IQueryable<Rule> query, string orderProperty, SearchOrder order)
        {
            var orderedQuery = (orderProperty.ToLower(), order) switch
            {
                ("name", SearchOrder.Asc) => query.OrderBy(x => x.Name),
                ("name", SearchOrder.Desc) => query.OrderByDescending(x => x.Name),
                ("id", SearchOrder.Asc) => query.OrderBy(x => x.Id),
                ("id", SearchOrder.Desc) => query.OrderByDescending(x => x.Id),
                ("code", SearchOrder.Asc) => query.OrderBy(x => x.Code),
                ("code", SearchOrder.Desc) => query.OrderByDescending(x => x.Code),
                ("group", SearchOrder.Asc) => query.OrderBy(x => x.Group),
                ("group", SearchOrder.Desc) => query.OrderByDescending(x => x.Group),
                ("index", SearchOrder.Asc) => query.OrderBy(x => x.Index),
                ("index", SearchOrder.Desc) => query.OrderByDescending(x => x.Index),
                _ => query.OrderBy(x => x.Index)
            };

            return orderedQuery;
        }
    }
}
