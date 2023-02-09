using eOrder.Domain.Rules.Entity;

namespace eOrder.Domain.Rules.UseCases.Common
{
    public class RuleOutput
    {
        public RuleOutput(long id, string name, string description, string group, int code, int index, bool runOnNews, bool runOnModification, bool isActive, string situationOnApprove, string situationOnDisapprove, string parameterType, string parameterOption)
        {
            Id = id;
            Name = name;
            Description = description;
            Group = group;
            Code = code;
            Index = index;
            RunOnNews = runOnNews;
            RunOnModification = runOnModification;
            IsActive = isActive;
            SituationOnApprove = situationOnApprove;
            SituationOnDisapprove = situationOnDisapprove;
            ParameterType = parameterType;
            ParameterOption = parameterOption;
        }

        public long Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; set; }
        public string Group { get; private set; }
        public int Code { get; private set; }
        public int Index { get; private set; }
        public bool RunOnNews { get; private set; }
        public bool RunOnModification { get; private set; }
        public bool IsActive { get; private set; }
        public string SituationOnApprove { get; private set; }
        public string SituationOnDisapprove { get; private set; }
        public string ParameterType { get; private set; }
        public string ParameterOption { get; private set; }

        public static RuleOutput FromEntity(Rule entity)
        {
            return new RuleOutput(
                id: entity.Id,
                name: entity.Name,
                description: entity.Description,
                group: entity.Group,
                code: entity.Code,
                index: entity.Index,
                runOnNews: entity.RunOnNews,
                runOnModification: entity.RunOnModification,
                isActive: entity.IsActive,
                situationOnApprove: entity.SituationOnApprove,
                situationOnDisapprove: entity.SituationOnDisapprove,
                parameterType: entity.ParameterType,
                parameterOption: entity.ParameterOption);
        }
    }
}
