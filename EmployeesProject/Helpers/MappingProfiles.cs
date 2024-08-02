using AutoMapper;
using EmployeesProject.Dto;
using EmployeesProject.Models;
using System.Net.Mail;

namespace EmployeesProject.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            // Client to ClientDto mapping
            CreateMap<Client, ClientDto>();

            // Employee to EmployeeDto mapping with ClientName
            CreateMap<Employee, EmployeeDto>()
                .ForMember(dest => dest.ClientName, opt => opt.MapFrom(src => src.Client.Name));

            // NewEmployeeDto to Employee mapping and reverse
            CreateMap<NewEmployeeDto, Employee>().ReverseMap();

            // Attachment to FileDto mapping with BaseCode as Base64 string
            CreateMap<Attachement, FileDto>()
                .ForMember(dest => dest.BaseCode, opt => opt.MapFrom(src => Convert.ToBase64String(src.Basecode)));

            // FileDto to Attachment mapping with Basecode as byte array
            CreateMap<FileDto,Attachement>()
                .ForMember(dest => dest.Basecode, opt => opt.MapFrom(src => src.GetBasecodeAsBytes()));

            // EmployeeStateDto to EmployeeState mapping and reverse
            CreateMap<EmployeeStateDto, Employeestate>().ReverseMap();
        }
    }
}
