using eOrder.Domain.Common.Exceptions;
using eOrder.Domain.DayOffs.Entities;
using eOrder.Domain.DayOffs.Repositories;
using eOrder.Domain.DayOffs.UseCases.Common;

namespace eOrder.Domain.DayOffs.UseCases.FindDayOff
{
    public class FindDayOff : IFindDayOff
    {

        private readonly IDayOffsRepository _dayOffsRepository;

        public FindDayOff(IDayOffsRepository dayOffsRepository)
        {
            _dayOffsRepository = dayOffsRepository;
        }

        public async Task<DayOffOutput> Handle(FindDayOffInput request, CancellationToken cancellationToken)
        {
            var dayOff = await _dayOffsRepository.Find(request.Id, cancellationToken);

            if (dayOff is null)
                throw new NotFoundException($"{nameof(DayOff)} not found");

            var output = DayOffOutput.FromEntity(dayOff);

            return output;
        }
    }
}
