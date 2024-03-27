using Microsoft.AspNetCore.Mvc;

namespace MergeRulesEngine.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MergeRulesController(IMergeRulesService service) : ControllerBase
    {
        private readonly IMergeRulesService _service = service;

        [HttpGet]
        public string ApplyRules(int minAge = 30, int maxAge = 50, string surname = "Smith", int customerNum = 12345678)
        {
            var parameters = new MergeRuleParameters
            {
                MinAge = minAge,
                MaxAge = maxAge,
                Surname = surname,
                CustomerNum = customerNum
            };

            return _service.ApplyRules(parameters);
        }
    }
}
