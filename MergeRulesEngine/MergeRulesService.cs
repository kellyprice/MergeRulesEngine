using System.Text.Json;

namespace MergeRulesEngine
{
    public class MergeRulesService : IMergeRulesService
    {
        private readonly IRule _ageRule;
        private readonly IRule _surnameRule;

        public MergeRulesService(
            [FromKeyedServices(RuleEnum.AgeRule)] IRule ageRule,
            [FromKeyedServices(RuleEnum.SurnameRule)] IRule surnameRule)
        {
            _ageRule = ageRule;
            _surnameRule = surnameRule;
        }

        public string ApplyRules(MergeRuleParameters parameters)
        {
            parameters.Errors = [];

            var ruleSets = new List<RuleSet>
            {
                new(false, [_ageRule, _surnameRule], parameters, true),
                new(true, [_ageRule], parameters, true),
                new(true, [_surnameRule], parameters, true)
            };

            foreach (var ruleSet in ruleSets)
            {
                parameters.Errors.AddRange(ruleSet.Errors());
            }

            parameters.RulesSuccess = ruleSets.All(x => x.Passed());

            parameters.Errors = parameters.Errors.Distinct().ToList();

            var serializedParameters = JsonSerializer.Serialize(parameters);

            // save serialized parameters before merge to db

            if (parameters.RulesSuccess)
            {
                try
                {
                    // do merge

                    parameters.MergeSuccess = true;
                }
                catch
                {
                    parameters.MergeSuccess = false;
                }
                finally
                {
                    // save serialized parameters after merge to db
                }
            }

            return serializedParameters;
        }
    }
}
