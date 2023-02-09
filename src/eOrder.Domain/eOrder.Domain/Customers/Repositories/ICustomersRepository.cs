using eOrder.Domain.Common.SeedWork;
using eOrder.Domain.Common.SeedWork.SearchableRepository;
using eOrder.Domain.Customers.Entities;

namespace eOrder.Domain.Customers.Repositories
{
    public interface ICustomersRepository : IGenericRepository<Customer>, ISearchableRepository<Customer>
    {
        Task<Customer?> FindByDocument(string document, CancellationToken cancellationToken);
        Task RemoveContact(Contact contact);
    }
}
