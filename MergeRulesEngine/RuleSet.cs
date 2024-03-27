namespace MergeRulesEngine
{
    public class RuleSet
    {
        private readonly bool _allRulesMustPass;
        private readonly List<IRule> _rules;
        private readonly MergeRuleParameters _parameters;
        private readonly bool _mandatory;

        public RuleSet(bool allRulesMustPass, List<IRule> rules, MergeRuleParameters parameters, bool mandatory)
        {
            _allRulesMustPass = allRulesMustPass;
            _rules = rules;
            _parameters = parameters;
            _mandatory = mandatory;

            ApplyAllRules();
        }

        public void ApplyAllRules()
        {
            foreach (var rule in _rules)
            {
                rule.ApplyRule(_parameters);
            }
        }

        public bool Passed()
        {
            if (!_mandatory)
            {
                return true;
            }
            else if (_allRulesMustPass)
            {
                return _rules.Count(x => !x.Passed) == 0;
            }

            return _rules.Any(x => x.Passed);
        }

        public List<string> Errors()
        {
            var errors = new List<string>();

            foreach (var rule in _rules)
            {
                if (!rule.Passed)
                {
                    errors.Add(rule.Error);
                }
            }

            return errors;
        }
    }
}
