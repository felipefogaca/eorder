using eOrder.Domain.DayOffs.UseCases.Common;
using MediatR;

namespace eOrder.Domain.DayOffs.UseCases.FindDayOff
{
    public interface IFindDayOff : IRequestHandler<FindDayOffInput, DayOffOutput>
    {

    }
}
