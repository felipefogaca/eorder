using eOrder.Domain.DayOffs.UseCases.Common;
using MediatR;

namespace eOrder.Domain.DayOffs.UseCases.CreateDayOff
{
    public interface ICreateDayOff : IRequestHandler<CreateDayOffInput, DayOffOutput>
    {
    }
}
