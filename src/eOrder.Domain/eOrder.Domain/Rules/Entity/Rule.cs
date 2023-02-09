using eOrder.Domain.Common.SeedWork;
using eOrder.Domain.Common.Validation;
using eOrder.Domain.Exceptions;

namespace eOrder.Domain.Rules.Entity
{
    public class Rule : AggregateRoot
    {
        public Rule(string name, string description, string group, int code, int index, bool runOnNews, bool runOnModification, string situationOnApprove, string situationOnDisapprove, string parameterType, string parameterOption)
        {
            Name = name;
            Description = description;
            Group = group;
            Code = code;
            Index = index;
            RunOnNews = runOnNews;
            RunOnModification = runOnModification;
            SituationOnApprove = situationOnApprove;
            SituationOnDisapprove = situationOnDisapprove;
            ParameterType = parameterType;
            ParameterOption = parameterOption;

            Validate();
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
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


        public void Update(
            string name,
            string description,
            string group,
            int index,
            bool runOnNews,
            bool runOnModification,
            string situationOnApprove,
            string situationOnDisapprove,
            string parameterType,
            string parameterOption)
        {
            Name = name;
            Description = description;
            Group = group;
            Index = index;
            RunOnNews = runOnNews;
            RunOnModification = runOnModification;
            SituationOnApprove = situationOnApprove;
            SituationOnDisapprove = situationOnDisapprove;
            ParameterType = parameterType;
            ParameterOption = parameterOption;


            Validate();
        }

        public void Activate()
        {
            IsActive = true;
            Validate();
        }

        public void Deactivate()
        {
            IsActive = false;
            Validate();
        }

        public void UpdateIndex(int index)
        {
            Index = index;
            //Validate();
        }
        private void Validate()
        {

            DomainValidation.NotNullOrEmpty(Name, nameof(Name));
            DomainValidation.MinLength(Name, 3, nameof(Name));
            DomainValidation.MaxLength(Name, 30, nameof(Name));
            
            DomainValidation.NotNullOrEmpty(Description, nameof(Description));
            DomainValidation.MinLength(Description, 10, nameof(Description));
            DomainValidation.MaxLength(Description, 100, nameof(Description));

            DomainValidation.NotNullOrEmpty(Group, nameof(Group));
            DomainValidation.MinLength(Group, 2, nameof(Group));
            DomainValidation.MaxLength(Group, 20, nameof(Group));


            var parameterTypeExists = ParameterTypes.Any(p => p == ParameterType);
            if (!parameterTypeExists)
                throw new EntityValidationException($"{nameof(ParameterType)} not exists");

            var parameterOptionExists = ParameterOptions.Any(p => p == ParameterOption);
            if (!parameterOptionExists)
                throw new EntityValidationException($"{nameof(ParameterOption)} not exists");

            var combinationExists = Combinations.Any(p => p.Item1 == ParameterType && p.Item2 == ParameterOption);
            if (!combinationExists)
                throw new EntityValidationException($"Combination {nameof(ParameterType)} '{ParameterType}' and {nameof(ParameterOption)} '{ParameterOption}' not exists");

            if (Index <= 0)
                throw new EntityValidationException($"{nameof(Index)} should be greater than zero");

        }

        public static class Type
        {
            public const string Boolean = "Boolean";
            public const string NoParameter = "NoParameter";
            public const string Number = "Number";
        }

        public static class Option
        {
            public const string Interval = "Interval";
            public const string Value = "Value";
            public const string Equitity = "Equitity";
            public const string NoOption = "";
        }

        public static readonly IReadOnlyCollection<string> ParameterTypes = new List<string>()
        {
            Type.Boolean,
            Type.NoParameter,
            Type.Number
        }.AsReadOnly();

        public static readonly IReadOnlyCollection<string> ParameterOptions = new List<string>()
        {
            Option.Interval,
            Option.Value,
            Option.Equitity,
            Option.NoOption

        }.AsReadOnly();

        public static readonly IReadOnlyCollection<(string, string)> Combinations = new List<(string, string)>()
        {
            new ("Boolean","Equitity"),
            new ("NoParameter", ""),
            new ("Number", "Equitity"),
            new ("Number", "Interval"),
            new ("Number", "Value")
        };
    }
}
