namespace MergeRulesEngine
{
    public class SurnameRule(IMergeRulesRepository repository) : RuleBase(repository)
    {
        public override void ApplyRule(MergeRuleParameters parameters)
        {
            var surname = _repository.SurnameRule();

            Passed = parameters.Surname == surname;

            if (!Passed)
            {
                Error = $"The source surname of {surname} is different to the target surname of {parameters.Surname}.";
            }
        }
    }
}
