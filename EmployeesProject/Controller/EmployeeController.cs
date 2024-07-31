﻿using AutoMapper;
using EmployeesProject.Dto;
using EmployeesProject.Interfaces;
using EmployeesProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesProject.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController: ControllerBase
    {
        private readonly IEmployee _employee;
        private readonly IMapper _maaper;

        public EmployeeController(IEmployee employee, IMapper maaper)
        {
            _employee = employee;
            _maaper= maaper;
        }

        [HttpGet("{pageNumber}/{pageSize}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<EmployeeDto>))]

        public IActionResult GetAllEmployees(int pageNumber, int pageSize)
        {
            if (pageNumber < 1 || pageSize < 1)
            {
                ModelState.AddModelError("", "Invalid page number or page size");
                return StatusCode(422, ModelState);
            }

            var allEmployeeRowsCount = _employee.CountTotalEmployees();
            if (allEmployeeRowsCount < pageSize)
            {
                pageSize = allEmployeeRowsCount;
                pageNumber = 1;
            }

            var results = _employee.GetAllEmployees(pageNumber, pageSize);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var mappedResults = _maaper.Map<List<EmployeeDto>>(results);
            return Ok(mappedResults);
        }

        [HttpGet("getTotalRows")]
        [ProducesResponseType(200, Type = typeof(int))]

        public IActionResult GetTotalEntries()
        {

            var allEmployeeRowsCount = _employee.CountTotalEmployees();
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(allEmployeeRowsCount);
        }

        [HttpGet("{employeeId}")]
        [ProducesResponseType(200, Type = typeof(EmployeeDto))]

        public IActionResult GetEmployeeById(int employeeId)
        {
            if (employeeId < 0) {
                ModelState.AddModelError("", "Invalid employee id");
                return StatusCode(400, ModelState);
            }

            var employee = _employee.GetEmployeeById(employeeId);
            if (employee == null) {
                ModelState.AddModelError("", "No Employee with this id exists");
                return StatusCode(400, ModelState);
            }
            var mappedEmployee = _maaper.Map<EmployeeDto>(employee);


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(mappedEmployee);
        }

    }
}