using eOrder.Domain.Common.SeedWork;
using eOrder.Domain.Compounds.Entities;
using eOrder.Domain.Compounds.Repositories;
using eOrder.Domain.Compounds.UseCases.Common;

namespace eOrder.Domain.Compounds.UseCases.CreateCompound
{
    public class CreateCompound : ICreateCompound
    {

        private readonly ICompoundsRepository _compoundsRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCompound(ICompoundsRepository compoundsRepository, IUnitOfWork unitOfWork)
        {
            _compoundsRepository = compoundsRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<CompoundOutput> Handle(CreateCompoundInput request, CancellationToken cancellationToken)
        {
            var compound = new Compound(
                0,
                request.Code,
                request.Description,
                request.CustomerId,
                request.IsActive,
                request.StandardQuantity);

            await _compoundsRepository.Insert(compound, cancellationToken);

            await _unitOfWork.Commit(cancellationToken);

            var output = CompoundOutput.FromEntity(compound);

            return output;
        }
    }
}
