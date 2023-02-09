namespace eOrder.Api.ApiModels.DayOffs
{
    public class UpdateDayOffApiInput
    {
        public UpdateDayOffApiInput(string name, DateTime date)
        {
            Name = name;
            Date = date;
        }

        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}
