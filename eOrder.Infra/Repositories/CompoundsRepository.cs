using eOrder.Domain.Compounds.Entities;
using eOrder.Domain.Compounds.Repositories;

namespace eOrder.Infra.Repositories
{
    public class CompoundsRepository : ICompoundsRepository
    {
        public Task Delete(Compound aggregate, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Compound?> Find(long id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Compound> FindByCode(string code, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Insert(Compound aggregate, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Update(Compound aggregate, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
