using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChildController : ControllerBase
    {
        private IChildService childService;

        public ChildController(IChildService service)
        {
            this.childService = service;
        }
        
        
        [HttpGet]
        public async Task<ActionResult<IList<Child>>> GetChildren()
        {
            try
            {
                IList<Child> children = await childService.GetChildrenAsync();
                return Ok(children);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Child>> AddChild([FromBody] Child child)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Child toAdd = await childService.AddChildAsync(child);
                return Created($"/{toAdd.Id}", toAdd);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}