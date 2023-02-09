using eOrder.Domain.DayOffs.UseCases.Common;
using MediatR;

namespace eOrder.Domain.DayOffs.UseCases.DeleteDayOff
{
    public class DeleteDayOffInput : IRequest<DayOffOutput>
    {
        public DeleteDayOffInput(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
