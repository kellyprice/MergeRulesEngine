namespace MergeRulesEngine
{
    public class RuleBase(IMergeRulesRepository repository) : IRule
    {
        protected readonly IMergeRulesRepository _repository = repository;

        public bool Passed { get; set; }
        public string Error { get; set; } = "";

        public virtual void ApplyRule(MergeRuleParameters parameters)
        {
            throw new NotImplementedException();
        }
    }
}
