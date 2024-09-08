using Portal2.BLL.Service.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Portal2.DAL.Entities;
using Portal2.DAl.Repo.interfaces;
using Microsoft.EntityFrameworkCore;
using Portal2.BLL.ModelVM.EmployeeVM;
using AutoMapper;
using Portal2.BLL.helper;



namespace Portal2.BLL.Service.implementation
{
    public class EmployeeService1 : IEmployeeService1
    {
        private readonly IEmployeeRepo employeeRepo;
        private readonly IMapper mapper;

        public EmployeeService1(IEmployeeRepo employeeRepo,IMapper mapper)
        {
            this.employeeRepo = employeeRepo;
            this.mapper = mapper;
        }
        public List<GetAllEmployeeVM> GetEmployeeList()
        {
            var result = employeeRepo.GetEmployeeList().ToList();
            var newdata = mapper.Map<List<GetAllEmployeeVM>>(result);
            
            return newdata;
        }

        public bool Create(CreateEmployeeVM empvm)
        {
            try
            {
                empvm.Image=UploadFile.UploadImage("Profile", empvm.ImageName);
                var result = mapper.Map<Employee>(empvm);

                return employeeRepo.Create(result);
            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool Update(UpdateEmployeeVM empvm)
        {
            try
            {
                var existingEmployee = employeeRepo.GetById(empvm.Id);
                if (existingEmployee != null)
                {
                    if (empvm.ImageName != null)
                    {
                        empvm.Image = UploadFile.UploadImage("Profile", empvm.ImageName);
                    }

                 
                    existingEmployee = mapper.Map(empvm, existingEmployee);

                    employeeRepo.Update(existingEmployee);
                    employeeRepo.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }



        public Employee GetById(int id)
        {
            return employeeRepo.GetById(id);
        }
        public bool Delete(int id)
        {
            try
            {
                var emp = employeeRepo.GetById(id);
                if (emp != null)
                {
                    emp.IsDeleted = !emp.IsDeleted;
                    employeeRepo.SaveChanges(); 
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}

