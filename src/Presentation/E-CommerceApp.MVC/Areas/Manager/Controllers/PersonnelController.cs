using E_CommerceApp.Application.Models.DTOs;
using E_CommerceApp.Application.Models.VMs;
using E_CommerceApp.Application.Services.AdminService;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceApp.MVC.Areas.Manager.Controllers
{
    [Area("Manager")]
    public class PersonnelController : Controller
    {
        private readonly IManagerService _managerService;

        public PersonnelController(IManagerService managerService)
        {
            _managerService = managerService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AddPersonnel()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddPersonnel(AddPersonnelDTO addPersonnelDTO)
        {
            if(ModelState.IsValid) 
            {
                await _managerService.CreatePersonnel(addPersonnelDTO);
                return RedirectToAction(nameof(ListOfPersonnels));
            }
            return View(addPersonnelDTO);
        }

        public async Task<IActionResult> ListOfPersonnels()
        {
            var personnels = await _managerService.GetPersonnels();
            return View(personnels);
        }

        [HttpGet]
        public async Task<IActionResult> UpdatePersonnel(Guid id)
        {
            var updatePersonnel = await _managerService.GetPersonnel(id);
            return View(updatePersonnel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePersonnel(UpdatePersonnelDTO updatePersonnelDTO)
        {
            if (ModelState.IsValid) 
            {
                await _managerService.UpdatePersonnel(updatePersonnelDTO);
                return RedirectToAction(nameof(ListOfPersonnels));
            }
            return View(updatePersonnelDTO);
        }

        public async Task<IActionResult> DeletePersonnel(Guid id)
        {
            await _managerService.DeletePersonnel(id);
            return RedirectToAction(nameof(ListOfPersonnels));
        }

    }
}
