using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Roulette.Core.Contract;
using Roulette.Core.Entity.DTO;

namespace Roulette.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RouletteController : ControllerBase
    {
        private readonly IRouletteService _rouletteService;

        public RouletteController(IRouletteService rouletteService)
        {
            _rouletteService = rouletteService;
        }

        [HttpPost("RegisterRoulette")]
        public IActionResult RegisterRoulette([FromBody] RouletteRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return StatusCode(500,"Model is not valid");
                
                var response = _rouletteService.CreateRoulette(request.name);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("OpenRoulette")]
        public IActionResult OpenRoulette([FromQuery] string id)
        {
            try
            {
                var response = _rouletteService.OpenRoulette(id);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost("CreateBet")]
        public IActionResult CreateBet([FromBody] RouletteRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return StatusCode(500, "Model is not valid");

                var response = _rouletteService.CreateRoulette(request.name);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
