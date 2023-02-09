using eOrder.Domain.Common.SeedWork.SearchableRepository;
using eOrder.Domain.Customers.Entities;
using eOrder.Domain.Customers.Repositories;
using Microsoft.EntityFrameworkCore;

namespace eOrder.Infra.Repositories
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly AppDbContext _appDbContext;

        public CustomersRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Task Delete(Customer aggregate, CancellationToken cancellationToken)
        {
            return Task.FromResult(_appDbContext.Remove(aggregate));
        }

        public async Task<Customer?> Find(long id, CancellationToken cancellationToken)
        {
            return await _appDbContext
                .Customers
                .Include(c => c.Contacts)
                .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
        }

        public async Task<Customer?> FindByDocument(string document, CancellationToken cancellationToken)
        {
            return await _appDbContext.Customers.FirstOrDefaultAsync(c => c.Document == document, cancellationToken);
        }

        public async Task Insert(Customer aggregate, CancellationToken cancellationToken)
        {
             await _appDbContext.AddAsync(aggregate, cancellationToken);
        }

        public Task Update(Customer aggregate, CancellationToken cancellationToken)
        {
            return Task.FromResult(_appDbContext.Update(aggregate));
        }

        public async Task<SearchOutput<Customer>> Search(SearchInput input, CancellationToken cancellationToken)
        {
            var toSkip = (input.Page - 1) * input.PerPage;
            var query = _appDbContext
                .Customers
                .Include(c => c.Contacts)
                .AsNoTracking();

            query = AddCustomerToQuery(query, input.OrderBy, input.Order);

            if (!string.IsNullOrWhiteSpace(input.Search))
            {
                query = query.Where(x => x.Name.Contains(input.Search)
                || x.Code.Contains(input.Search) || x.Document.Contains(input.Search));
            }

            var items = await query
                .Skip(toSkip)
                .Take(input.PerPage)
                .ToListAsync(cancellationToken);

            var count = await query.CountAsync(cancellationToken);

            return new SearchOutput<Customer>(
                input.Page,
                input.PerPage,
                count,
                items.AsReadOnly());

        }

        private static IQueryable<Customer> AddCustomerToQuery(IQueryable<Customer> query, string orderProperty, SearchOrder order)
        {
            var orderedQuery = (orderProperty.ToLower(), order) switch
            {
                ("name", SearchOrder.Asc) => query.OrderBy(x => x.Name)
                    .ThenBy(x => x.Id),
                ("name", SearchOrder.Desc) => query.OrderByDescending(x => x.Name)
                    .ThenByDescending(x => x.Id),
                ("id", SearchOrder.Asc) => query.OrderBy(x => x.Id),
                ("id", SearchOrder.Desc) => query.OrderByDescending(x => x.Id),
                ("code", SearchOrder.Asc) => query.OrderBy(x => x.Code),
                ("code", SearchOrder.Desc) => query.OrderByDescending(x => x.Code),
                ("document", SearchOrder.Asc) => query.OrderBy(x => x.Document),
                ("document", SearchOrder.Desc) => query.OrderByDescending(x => x.Document),
                _ => query.OrderBy(x => x.Name)
                    .ThenBy(x => x.Id)
            };
            return orderedQuery;
        }

        public Task RemoveContact(Contact contact)
        {
            return Task.FromResult(_appDbContext.Remove(contact));
        }
    }
}
