using eOrder.Domain.Common.Exceptions;
using eOrder.Domain.DayOffs.Entities;
using eOrder.Domain.DayOffs.Repositories;
using eOrder.Domain.DayOffs.UseCases.Common;

namespace eOrder.Domain.DayOffs.UseCases.DeleteDayOff
{
    public class DeleteDayOff : IDeleteDayOff
    {

        private readonly IDayOffsRepository _dayOffsRepository;

        public DeleteDayOff(IDayOffsRepository dayOffsRepository)
        {
            _dayOffsRepository = dayOffsRepository;
        }

        public async Task<DayOffOutput> Handle(DeleteDayOffInput request, CancellationToken cancellationToken)
        {
            var dayOff = await _dayOffsRepository.Find(request.Id, cancellationToken);

            if (dayOff == null)
                throw new NotFoundException($"{nameof(DayOff)} not found");

            await _dayOffsRepository.Delete(dayOff, cancellationToken);

            var output = DayOffOutput.FromEntity(dayOff);

            return output;
        }
    }
}
