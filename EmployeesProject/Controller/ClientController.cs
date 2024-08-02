using AutoMapper;
using EmployeesProject.Dto;
using EmployeesProject.Interfaces;
using EmployeesProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesProject.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClient _client;
        private readonly IMapper _maap;
        public ClientController(IClient client, IMapper maap)
        {
            _client = client;
            _maap = maap;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Client>))]

        public IActionResult GetAllClients()
        {
            var states = _client.GetAllClients();
            var mappedClients = _maap.Map<List<Client>>(states);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(mappedClients);
        }

        [HttpGet("{clientid}")]
        [ProducesResponseType(200, Type = typeof(Client))]
        public IActionResult GetClientbyid(int clientid)
        {
            var client = _client.GetClientById(clientid);
            
            if(client == null)
            {
                ModelState.AddModelError("", "No Client with this id exists");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(client);
        }
    }
}