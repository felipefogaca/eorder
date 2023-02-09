using eOrder.Domain.DayOffs.UseCases.Common;
using MediatR;

namespace eOrder.Domain.DayOffs.UseCases.FindDayOff
{
    public class FindDayOffInput : IRequest<DayOffOutput>
    {
        public FindDayOffInput(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
