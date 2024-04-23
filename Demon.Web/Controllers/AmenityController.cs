using Demon.Application.Common.Interfaces;
using Demon.Application.Common.Utility;
using Demon.Domain.Entities;
using Demon.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Demon.Web.Controllers
{
    [Authorize(Roles = SD.Role_Admin)]
    public class AmenityController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public AmenityController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var amenity = _unitOfWork.Amenity.GetAll(includeProperties: "Villa");
            return View(amenity);
        }
        public IActionResult Create()
        {
            AmenityVM amenityVM = new()
            {
                VillaList = _unitOfWork.Villa.GetAll().Select(v => new SelectListItem
                {
                    Text = v.Name,
                    Value = v.Id.ToString()
                })
            };
            return View(amenityVM);
        }
        [HttpPost]
        public IActionResult Create(AmenityVM obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Amenity.Add(obj.Amenity);
                _unitOfWork.Save();
                TempData["success"] = "The amenity has been created successfully";
                return RedirectToAction("Index", "Amenity");
            }
            if (_unitOfWork.Amenity.Any(v => v.Name == obj.Amenity.Name))
            {
                TempData["error"] = "The amenity already exists";
            }
            return View(obj);
        }
        public IActionResult Update(int amenityId)
        {
            AmenityVM amenityVm = new()
            {
                VillaList = _unitOfWork.Villa.GetAll().Select(v => new SelectListItem
                {
                    Text = v.Name,
                    Value = v.Id.ToString()
                }),
                Amenity = _unitOfWork.Amenity.Get(v => v.Id == amenityId)
            };
            if (amenityVm.Amenity is null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(amenityVm);
        }
        [HttpPost]
        public IActionResult Update(AmenityVM obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Amenity.Update(obj.Amenity);
                _unitOfWork.Save();
                TempData["success"] = "The amenity has been updated successfully";
                return RedirectToAction("Index", "Amenity");
            }
            if (_unitOfWork.Amenity.Any(v => v.Name == obj.Amenity.Name))
            {
                TempData["error"] = "The amenity already exists";
            }
            return View(obj);
        }
        public IActionResult Delete(int amenityId)
        {
            AmenityVM amenityVm = new()
            {
                VillaList = _unitOfWork.Villa.GetAll().Select(v => new SelectListItem
                {
                    Text = v.Name,
                    Value = v.Id.ToString()
                }),
                Amenity = _unitOfWork.Amenity.Get(v => v.Id == amenityId)
            };
            if (amenityVm.Amenity is null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(amenityVm);
        }
        [HttpPost]
        public IActionResult Delete(AmenityVM obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Amenity.Remove(obj.Amenity);
                _unitOfWork.Save();
                TempData["success"] = "The amenity has been updated successfully";
                return RedirectToAction("Index", "Amenity");
            }
            if (_unitOfWork.Amenity.Any(v => v.Name == obj.Amenity.Name))
            {
                TempData["error"] = "The amenity already exists";
            }
            return View(obj);
        }
    }
}
