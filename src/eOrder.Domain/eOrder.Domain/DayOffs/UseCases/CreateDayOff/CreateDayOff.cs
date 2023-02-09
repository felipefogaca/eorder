using eOrder.Domain.Common.SeedWork;
using eOrder.Domain.DayOffs.Entities;
using eOrder.Domain.DayOffs.Repositories;
using eOrder.Domain.DayOffs.UseCases.Common;

namespace eOrder.Domain.DayOffs.UseCases.CreateDayOff
{
    public class CreateDayOff : ICreateDayOff
    {
        private readonly IDayOffsRepository _dayOffsRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateDayOff(IDayOffsRepository dayOffsRepository, IUnitOfWork unitOfWork)
        {
            _dayOffsRepository = dayOffsRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<DayOffOutput> Handle(CreateDayOffInput request, CancellationToken cancellationToken)
        {
            var dayOff = new DayOff(
                request.Name,
                request.Date);

            await _dayOffsRepository.Insert(dayOff, cancellationToken);

            await _unitOfWork.Commit(cancellationToken);

            var output = DayOffOutput.FromEntity(dayOff);

            return output;
        }
    }
}
