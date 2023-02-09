using eOrder.Domain.Common.Exceptions;
using eOrder.Domain.Compounds.Entities;
using eOrder.Domain.Compounds.Repositories;
using eOrder.Domain.Compounds.UseCases.Common;

namespace eOrder.Domain.Compounds.UseCases.FindCompound
{
    public class FindCompound : IFindCompound
    {
        private readonly ICompoundsRepository _compoundsRepository;

        public FindCompound(ICompoundsRepository compoundsRepository)
        {
            _compoundsRepository = compoundsRepository;
        }

        public async Task<CompoundOutput> Handle(FindCompoundInput request, CancellationToken cancellationToken)
        {
            var compound = await _compoundsRepository.Find(request.Id, cancellationToken);

            if (compound == null)
                throw new NotFoundException($"{nameof(Compound)} not found");

            var output = CompoundOutput.FromEntity(compound);

            return output;
        }
    }
}
