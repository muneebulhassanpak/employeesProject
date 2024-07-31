using AutoMapper;
using EmployeesProject.Dto;
using EmployeesProject.Models;

namespace EmployeesProject.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        { 
            CreateMap <Client,ClientDto>();
            CreateMap <Employee,EmployeeDto>();
        }
    }
}
