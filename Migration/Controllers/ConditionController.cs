using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interfaces.Repositories;
using Application.Queries.Condition;

namespace Migration.Controllers
{
    public class ConditionController : BaseApiController
    {
        private readonly IConditionQueries _conditionQueries;

        public ConditionController(IConditionQueries conditionQueries)
        {
            _conditionQueries = conditionQueries;
        }


        [HttpGet]
        public async Task<IActionResult> GetConditionsByLawyerId(int id)
        {
            var result = await _conditionQueries.GetConditionsByLawyerId(id);
            return Ok(result);
        }
    }
}
