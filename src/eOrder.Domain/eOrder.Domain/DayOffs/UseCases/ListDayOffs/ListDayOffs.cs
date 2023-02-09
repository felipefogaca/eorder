using eOrder.Domain.DayOffs.Repositories;
using eOrder.Domain.DayOffs.UseCases.Common;

namespace eOrder.Domain.DayOffs.UseCases.ListDayOffs
{
    public class ListDayOffs : IListDayOffs
    {
        private readonly IDayOffsRepository _dayOffsRepository;

        public ListDayOffs(IDayOffsRepository dayOffsRepository)
        {
            _dayOffsRepository = dayOffsRepository;
        }

        public async Task<List<DayOffOutput>> Handle(ListDayOffsInput request, CancellationToken cancellationToken)
        {
            var items = await _dayOffsRepository.Search(request.StartDate, request.EndDate, cancellationToken);

            var output = items
                .Select(x => DayOffOutput.FromEntity(x))
                .ToList();

            return output;
        }
    }
}
