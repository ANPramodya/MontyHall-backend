
using Microsoft.AspNetCore.Mvc;
using MontyHall.Models;
using MontyHall.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MontyHall.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimulationController : ControllerBase
    {
        private readonly ISimulationService _simulationService;
        

        public SimulationController(ISimulationService simulationService)
        {
            _simulationService = simulationService;
           
        }


        //// GET: api/<SimulationController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<SimulationController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<SimulationController>
        [HttpPost]
        public async Task<ActionResult<MontyHallSimulationResult>> GenerateSimulation([FromBody] MontyHallSimulationInput simulationInput)
        {
            var simulationResult = _simulationService.GenerateSimulation(simulationInput.NoOfGames, simulationInput.SwitchDoors);
            return Ok(simulationResult);
        }

        

        //// PUT api/<SimulationController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<SimulationController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
