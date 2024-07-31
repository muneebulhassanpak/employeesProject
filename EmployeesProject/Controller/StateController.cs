using EmployeesProject.Interfaces;
using EmployeesProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesProject.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IState _state;       
        public StateController(IState state)
        {
            _state = state;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<State>))]

        public IActionResult GetAllStates() {
            var states = _state.GtAllStates();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(states);
        }
    }
}
