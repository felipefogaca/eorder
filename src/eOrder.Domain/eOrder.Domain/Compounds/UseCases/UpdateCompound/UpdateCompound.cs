using eOrder.Domain.Common.Exceptions;
using eOrder.Domain.Common.SeedWork;
using eOrder.Domain.Compounds.Entities;
using eOrder.Domain.Compounds.Repositories;
using MediatR;

namespace eOrder.Domain.Compounds.UseCases.UpdateCompound
{
    public class UpdateCompound : IUpdateCompound
    {
        private readonly ICompoundsRepository _compoundsRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCompound(ICompoundsRepository compoundsRepository, IUnitOfWork unitOfWork)
        {
            _compoundsRepository = compoundsRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateCompoundInput request, CancellationToken cancellationToken)
        {
            var compound = await _compoundsRepository.Find(request.Id, cancellationToken);

            if (compound is null)
                throw new NotFoundException($"{nameof(Compound)} not found");

            compound.Update(request.Description);

            if (request.IsActive)
                compound.Activate();
            else
                compound.Deactivate();

            await _compoundsRepository.Update(compound, cancellationToken);

            await _unitOfWork.Commit(cancellationToken);

            return Unit.Value;
        }
    }
}
