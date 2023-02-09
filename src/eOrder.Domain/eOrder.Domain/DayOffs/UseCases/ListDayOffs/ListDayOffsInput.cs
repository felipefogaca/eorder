using eOrder.Domain.DayOffs.UseCases.Common;
using MediatR;

namespace eOrder.Domain.DayOffs.UseCases.ListDayOffs
{
    public class ListDayOffsInput : IRequest<List<DayOffOutput>>
    {
        public ListDayOffsInput(DateTime? startDate = null, DateTime? endDate = null)
        {
            if (startDate == null)
                startDate = DateTime.Now;

            if (endDate == null)
                endDate = DateTime.Now.AddDays(10);
            StartDate = startDate.Value;
            EndDate = endDate.Value;
        }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
