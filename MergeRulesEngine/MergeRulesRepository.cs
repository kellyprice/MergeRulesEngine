namespace MergeRulesEngine
{
    public class MergeRulesRepository : IMergeRulesRepository
    {
        public string SurnameRule()
        {
            var matchedSurname = "Jones";

            return matchedSurname;
        }

        public int AgeRule()
        {
            var age = 45;

            return age;
        }
    }
}
