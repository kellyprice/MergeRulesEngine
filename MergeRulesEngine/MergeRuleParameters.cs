namespace MergeRulesEngine
{
    [Serializable]
    public class MergeRuleParameters
    {
        public int CustomerNum { get; set; }

        public int MinAge { get; set; }

        public int MaxAge { get; set; }

        public string? Surname { get; set; }

        public List<string>? Errors { get; set; }

        public bool RulesSuccess { get; set; }

        public bool MergeSuccess { get; set; }
    }
}
