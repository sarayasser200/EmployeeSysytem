using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Portal2.BLL.helper;
using Portal2.BLL.ModelVM.EmployeeVM;
using Portal2.BLL.Service.interfaces;
using Portal2.BLL.Service.Interfaces;
using Portal2.DAl.Entities;
using Portal2.DAL.Entities;
using System.Security.Claims;

namespace Portal2.pll.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService1 employeeService;
        private readonly IDepartmentService departmentService; // Corrected service name
        private readonly IMapper mapper;

        public EmployeeController(IEmployeeService1 employeeService, IDepartmentService departmentService, IMapper mapper) // Added departmentService here
        {
            this.employeeService = employeeService;
            this.departmentService = departmentService; // Corrected service assignment
            this.mapper = mapper;
        }
         
        public IActionResult TestClaim()
        {
            string name = User.Identity.Name;
            Claim Idclaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

            return Content("Claim to user Id =" + Idclaim.Value);
        }
        public IActionResult Index()
        {
            return View(employeeService.GetEmployeeList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new CreateEmployeeVM
            {
               
                Departments = departmentService.GetDepartments().Select(d => new SelectListItem
                {
                    Value = d.Id.ToString(),
                    Text = d.Name
                }).ToList()
            };

            return View(viewModel);
        }


        [HttpPost]
        public IActionResult CreateEmployee(CreateEmployeeVM emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Delegate image upload to the service layer
                    if (emp.ImageName != null)
                    {
                        // Process the file
                        var fileName = UploadFile.UploadImage("Profile",emp.ImageName);
                        emp.Image = fileName; // Save the file name to the model or database
                    }
                    if (emp.SelectedDepartmentId!=null){
                        emp.DeptId = emp.SelectedDepartmentId;
                    }

                    if (employeeService.Create(emp))
                       
                        return RedirectToAction("Index");
                    else
                        ViewBag.ErrorMessage = "Error creating the employee.";
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }

            //// Repopulate Departments list on failure
            emp.Departments = departmentService.GetDepartments().Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = d.Name
            });
            return View("Create", emp);
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var employee = employeeService.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }

            var model = mapper.Map<UpdateEmployeeVM>(employee);


            model.Departments = departmentService.GetDepartments().Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = d.Name
            });


            return View(model);
        }

        [HttpPost]
        public IActionResult Update(UpdateEmployeeVM model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageName != null)
                {
                    
                    var fileName = UploadFile.UploadImage("Profile", model.ImageName);
                    model.Image = fileName;
                }
                if (model.SelectedDepartmentId != null)
                {
                    model.DeptId = model.SelectedDepartmentId;
                }
                var isUpdated = employeeService.Update(model);
                if (isUpdated)
                {
                    return RedirectToAction("Index");
                }
            }
            model.Departments = departmentService.GetDepartments().Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = d.Name
            });
            return View(model);
        }

        public IActionResult Details(int id)
        {
            var employee = employeeService.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }

            var model = mapper.Map<GetEmployeeDetailsVM>(employee);
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var data = employeeService.GetById(id);
            if (data == null)
            {
                return NotFound();
            }
            var model = mapper.Map<DeleteEmployeeVM>(data);

            return View(model);
        }

        [HttpPost]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                if (employeeService.Delete(id))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.ErrorMessage = "Error deleting the employee.";
                    var employee = employeeService.GetById(id);
                    if (employee == null)
                    {
                        return NotFound();
                    }

                    // Map the employee entity back to DeleteEmployeeVM
                    var model = mapper.Map<DeleteEmployeeVM>(employee);
                    return View("Delete", model);
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                var employee = employeeService.GetById(id);
                if (employee == null)
                {
                    return NotFound();
                }

                // Map the employee entity back to DeleteEmployeeVM
                var model = mapper.Map<DeleteEmployeeVM>(employee);
                return View("Delete", model);
            }
        }

    }
}
