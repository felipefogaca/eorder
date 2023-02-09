using eOrder.Domain.DayOffs.Entities;

namespace eOrder.Domain.DayOffs.UseCases.Common
{
    public class DayOffOutput
    {
        public DayOffOutput(long id, string name, DateTime date)
        {
            Id = id;
            Name = name;
            Date = date;
        }

        public long Id { get; private set; }
        public string Name { get; private set; }
        public DateTime Date { get; private set; }

        public static DayOffOutput FromEntity(DayOff entity)
        {
            return new DayOffOutput(
                entity.Id,
                entity.Name,
                entity.Date);
        }
    }
}
