using eOrder.Domain.DayOffs.UseCases.Common;
using MediatR;

namespace eOrder.Domain.DayOffs.UseCases.CreateDayOff
{
    public class CreateDayOffInput : IRequest<DayOffOutput>
    {
        public CreateDayOffInput(string name, DateTime date)
        {
            Name = name;
            Date = date;
        }

        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}
