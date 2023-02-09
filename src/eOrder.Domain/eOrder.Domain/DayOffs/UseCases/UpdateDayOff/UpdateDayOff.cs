using eOrder.Domain.Common.Exceptions;
using eOrder.Domain.Common.SeedWork;
using eOrder.Domain.DayOffs.Entities;
using eOrder.Domain.DayOffs.Repositories;
using MediatR;

namespace eOrder.Domain.DayOffs.UseCases.UpdateDayOff
{
    public class UpdateDayOff : IUpdateDayOff
    {
        private readonly IDayOffsRepository _dayOffsRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateDayOff(IDayOffsRepository dayOffsRepository, IUnitOfWork unitOfWork)
        {
            _dayOffsRepository = dayOffsRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateDayOffInput request, CancellationToken cancellationToken)
        {
            var dayOff = await _dayOffsRepository.Find(request.Id, cancellationToken);

            if (dayOff == null)
                throw new NotFoundException($"{nameof(DayOff)} not found");

            dayOff.Update(
                request.Name,
                request.Date);

            await _dayOffsRepository.Update(dayOff, cancellationToken);

            await _unitOfWork.Commit(cancellationToken);

            return Unit.Value;
        }
    }
}
