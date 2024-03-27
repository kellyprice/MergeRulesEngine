namespace MergeRulesEngine
{
    public interface IRule
    {
        bool Passed { get; }

        string Error { get; }

        void ApplyRule(MergeRuleParameters parameters);
    }
}
