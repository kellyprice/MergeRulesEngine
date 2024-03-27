namespace MergeRulesEngine
{
    public class AgeRule(IMergeRulesRepository repository) : RuleBase(repository)
    {
        public override void ApplyRule(MergeRuleParameters parameters)
        {
            var age = _repository.AgeRule();

            Passed = parameters.MinAge <= age && age <= parameters.MaxAge;

            if (!Passed)
            {
                Error = $"The target age of {age} is not between the ages of {parameters.MinAge} and {parameters.MaxAge}.";
            }
        }
    }
}
