using eOrder.Domain.DayOffs.UseCases.Common;

namespace eOrder.Domain.DayOffs.UseCases.DeleteDayOff
{
    public interface IDeleteDayOff : MediatR.IRequestHandler<DeleteDayOffInput, DayOffOutput>
    {

    }
}
