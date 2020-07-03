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
                    return BadRequest("Model is not valid");
                
                var response = _rouletteService.CreateRoulette(request.name);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("OpenRoulette")]
        public IActionResult OpenRoulette([FromQuery] Int64 id)
        {
            try
            {
                var jsonResponse = new
                {
                    id,
                    date = DateTime.UtcNow,
                    open = _rouletteService.OpenRoulette(id),

                };

                return Ok(jsonResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("CreateBet")]
        public IActionResult CreateBet([FromHeader(Name = "UserId")] String UserId, [FromBody] BetRequest bet)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Model is not valid");

                var jsonResponse = new
                {
                    bet.Color,
                    bet.Number,
                    created = _rouletteService.CreateBet(bet),
                };
                return Ok(jsonResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("CloseBets")]
        public IActionResult CloseBets([FromQuery] Int64 id)
        {
            try
            {
                var response = _rouletteService.GetBets();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetRoulettes")]
        public IActionResult GetRoulettes()
        {
            try
            {
                var response = _rouletteService.GetRoulettes();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
