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
    public class ToyController : ControllerBase
    {
        private IToyService toyService;

        public ToyController(IToyService toyService)
        {
            this.toyService = toyService;
        }


        [HttpPost]
        public async Task<ActionResult<Toy>> AddToyAsync([FromBody] Toy toy)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Toy added = await toyService.AddToyAsync(toy);
                return Created($"/{added.Id}", added);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IList<Toy>>> getToysAsync()
        {
            try
            {
                IList<Toy> toys = await toyService.GetToysAsync();
                return Ok(toys);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> DeleteAdult([FromRoute] int id)
        {
            try
            {
                await toyService.RemoveToyAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        
    }
}