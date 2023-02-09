using eOrder.Domain.DayOffs.UseCases.Common;
using MediatR;

namespace eOrder.Domain.DayOffs.UseCases.ListDayOffs
{
    public interface IListDayOffs : IRequestHandler<ListDayOffsInput, List<DayOffOutput>>
    {
    }
}
