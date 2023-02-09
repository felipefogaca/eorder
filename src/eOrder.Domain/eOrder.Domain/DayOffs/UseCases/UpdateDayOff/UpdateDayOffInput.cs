using MediatR;

namespace eOrder.Domain.DayOffs.UseCases.UpdateDayOff
{
    public class UpdateDayOffInput : IRequest
    {
        public UpdateDayOffInput(long id, string name, DateTime date)
        {
            Id = id;
            Name = name;
            Date = date;
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }

        
    }
}
