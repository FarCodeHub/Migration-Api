using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands;
using Application.Commands.PersonLawyer.Create;

namespace Migration.Controllers
{
    public class PersonLawyerController : BaseApiController
    {
    

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreatePersonLawyerCommand command) =>
            Ok(await mediator.Send(command));
    }
}
