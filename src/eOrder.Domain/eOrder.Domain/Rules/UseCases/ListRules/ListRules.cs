using eOrder.Domain.Rules.Repositories;

namespace eOrder.Domain.Rules.UseCases.ListRules
{
    public class ListRules : IListRules
    {
        private readonly IRulesRepository _rulesRepository;

        public ListRules(IRulesRepository rulesRepository)
        {
            _rulesRepository = rulesRepository;
        }

        public async Task<ListRulesOutput> Handle(ListRulesInput request, CancellationToken cancellationToken)
        {
            var searchOutput = await _rulesRepository.Search(request.ToSearchInput(), cancellationToken);

            return ListRulesOutput.FromSearchOutput(searchOutput);
        }
    }
}
