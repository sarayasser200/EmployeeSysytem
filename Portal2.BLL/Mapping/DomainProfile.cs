using AutoMapper;
using Portal2.BLL.ModelVM.EmployeeVM;
using Portal2.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal2.BLL.Mapping
{
    public class DomainProfile:Profile
    {
        public DomainProfile()
        {
            //From entity to vm 
            CreateMap<Employee, GetAllEmployeeVM>();
            CreateMap<CreateEmployeeVM,Employee>();
            CreateMap<Employee, UpdateEmployeeVM>().ReverseMap();
            CreateMap<Employee, GetEmployeeDetailsVM>();
            CreateMap<CreateEmployeeVM, Employee>();
            CreateMap<CreateEmployeeVM, Employee>()
    .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image)); // Ensure Image is mapped
            CreateMap<Employee, DeleteEmployeeVM>().ForMember(dest => dest.ImageName, opt => opt.Ignore()); 
        }


    }
        
    }
