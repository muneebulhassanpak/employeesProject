using AutoMapper;
using EmployeesProject.Dto;
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
        private readonly IMapper _mapper;       
        public StateController(IState state, IMapper mapper)
        {
            _state = state;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<State>))]

        public IActionResult GetAllStates() {
            var states = _state.GetAllStates();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var mappedStates= _mapper.Map<List<EmployeeStateDto>>(states);
            return Ok(mappedStates);
        }

        [HttpGet("{stateId}")]
        [ProducesResponseType(200, Type = typeof(State))]
        public IActionResult GetStateByid(int stateId)
        {
            var foundState = _state.GetStateById(stateId);

            if (foundState == null)
            {
                ModelState.AddModelError("", "No State Found");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(foundState);
        }
    }
}
