using MediatR;

namespace eOrder.Domain.Rules.UseCases.UpdateRule
{
    public class UpdateRuleInput : IRequest
    {
        public UpdateRuleInput(long id, string name, string description, string group, int code, int index, bool runOnNews, bool runOnModification, bool isActive, string situationOnApprove, string situationOnDisapprove, string parameterType, string parameterOption)
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

        public long Id { get; set; }
        public string Name { get;  set; }
        public string Description { get;  set; }
        public string Group { get;  set; }
        public int Code { get;  set; }
        public int Index { get;  set; }
        public bool RunOnNews { get;  set; }
        public bool RunOnModification { get;  set; }
        public bool IsActive { get;  set; }
        public string SituationOnApprove { get;  set; }
        public string SituationOnDisapprove { get;  set; }
        public string ParameterType { get;  set; }
        public string ParameterOption { get;  set; }
    }
}
