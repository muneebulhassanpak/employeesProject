﻿using EmployeesProject.Dto;
using EmployeesProject.Interfaces;
using EmployeesProject.Models;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Net.Mail;
using Microsoft.EntityFrameworkCore;

namespace EmployeesProject.Repository
{
    public class EmployeeRepository : IEmployee
    {
        private readonly employeeDatabaseContext _context;
        private readonly IClient _client;
        private readonly IState _state;
        private readonly IMapper _mapper;

        public EmployeeRepository(employeeDatabaseContext context, IClient client, IState state, IMapper mapper)
        {
            _context = context;
            _client = client;
            _state = state;
            _mapper = mapper;
        }

        public ICollection<Employee> GetAllEmployees(int pageNumber, int pageSize)
        {
            int toBeMissed = pageSize * (pageNumber - 1);

            var employees = _context.Employees
                                    .OrderBy(e => e.Id)
                                    .Skip(toBeMissed)
                                    .Take(pageSize)
                                    .ToList();

            return employees;
        }

        public int CountTotalEmployees()
        {
            return _context.Employees.Count();
        }

        public Employee GetEmployeeById(int employeeId)
        {
            return _context.Employees.FirstOrDefault(emp => emp.Id == employeeId);
        }

        public async Task<Employee> CreateNewEmployee(NewEmployeeDto newEmployeeDto)
        {
            //var targetClient = _client.GetClientById(newEmployeeDto.ClientId);
           
            var employee = _mapper.Map<Employee>(newEmployeeDto);

            //employee.Client = targetClient;

            _context.Employees.Add(employee);

             await _context.SaveChangesAsync();

            return employee;
        }
        public async Task<Employee?> EditEmployee(NewEmployeeDto newEmployeeDto)
        {
            var empId = newEmployeeDto.Id;

            var targetEmployee = await _context.Employees.AsNoTracking()
                .Include(e => e.Employeestates)
                .Include(e => e.Attachements)
                .FirstOrDefaultAsync(e => e.Id == empId);

            if (targetEmployee == null)
            {
                return null;
            }

            // Update targetEmployee with newEmployeeDto properties
            _mapper.Map(newEmployeeDto, targetEmployee);
            _context.Entry(targetEmployee).State = EntityState.Detached;

            // Remove existing states and attachments
            _context.Employeestates.RemoveRange(targetEmployee.Employeestates);
            _context.Attachements.RemoveRange(targetEmployee.Attachements);

            // Add updated states and attachments
            targetEmployee.Employeestates = newEmployeeDto.Employeestates.Select(es => _mapper.Map<Employeestate>(es)).ToList();
            targetEmployee.Attachements = newEmployeeDto.Attachements.Select(a => _mapper.Map<Attachement>(a)).ToList();


            await _context.SaveChangesAsync();

            return targetEmployee;
        }





        public bool Save()
        {
            var status = _context.SaveChanges();
            return status > 0;
        }
    }
}
