
using Demon.Application.Common.Interfaces;
using Demon.Application.Common.Utility;
using Demon.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Demon.Web.Controllers
{
    [Authorize(Roles = SD.Role_Admin)]
    public class VillaNumberController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public VillaNumberController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var villaNumber = _unitOfWork.VillaNumber.GetAll(includeProperties: "Villa");
            return View(villaNumber);
        }
        public IActionResult Create()
        {

            VillaNumberVM villaNumberVM = new()
            {

                VillaList = _unitOfWork.Villa.GetAll().Select(v => new SelectListItem
                {
                    Text = v.Name,
                    Value = v.Id.ToString()
                })
            };
            //};
            //IEnumerable<SelectListItem> list = _db.Villa.Select(v => new SelectListItem
            //{
            //    Value = v.Id.ToString(),
            //    Text = v.Name
            //});

            //ViewData["VillaList"] = list;
            //ViewBag.VillaList = list;
            return View(villaNumberVM);
        }
        [HttpPost]
        public IActionResult Create(VillaNumberVM obj)
        {
            //ModelState.Remove("Villa");
            if (ModelState.IsValid)
            {
                _unitOfWork.VillaNumber.Add(obj.VillaNumber);
                _unitOfWork.Save();
                TempData["success"] = "The villa has been created successfully";
                return RedirectToAction("Index", "VillaNumber");
            }
            if (_unitOfWork.VillaNumber.Any(v => v.Villa_Number == obj.VillaNumber.Villa_Number))
            {
                TempData["error"] = "The villa has not been created";

            }
            obj.VillaList = _unitOfWork.Villa.GetAll().Select(v => new SelectListItem
            {
                Text = v.Name,
                Value = v.Id.ToString()
            });
            return View(obj);

        }
        public IActionResult Update(int villaNumberId)
        {
            VillaNumberVM villaNumberVM = new()
            {
                VillaList = _unitOfWork.Villa.GetAll().Select(v => new SelectListItem
                {
                    Text = v.Name,
                    Value = v.Id.ToString()
                }),
                VillaNumber = _unitOfWork.VillaNumber.Get(v => v.Villa_Number == villaNumberId)
            };
            if (villaNumberVM.VillaNumber == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(villaNumberVM);
        }
        [HttpPost]
        public IActionResult Update(VillaNumberVM obj)
        {
            var existingVillaNumber = _unitOfWork.VillaNumber.Get(v => v.Villa_Number == obj.VillaNumber.Villa_Number); ;

            if (existingVillaNumber != null)
            {
                TempData["error"] = "The villa number already exists";
                return View(obj);
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.VillaNumber.Update(obj.VillaNumber);
                _unitOfWork.Save();
                TempData["success"] = "The villa has been created successfully";
                return RedirectToAction("Index", "VillaNumber");
            }
            if (_unitOfWork.VillaNumber.Any(v => v.Villa_Number == obj.VillaNumber.Villa_Number))
            {
                TempData["error"] = "The villa has not been created";

            }
            return View(obj);
        }
        public IActionResult Delete(int villaNumberId)
        {
            VillaNumberVM villaNumberVM = new()
            {
                VillaList = _unitOfWork.Villa.GetAll().Select(v => new SelectListItem
                {
                    Text = v.Name,
                    Value = v.Id.ToString()
                }),
                VillaNumber = _unitOfWork.VillaNumber.Get(v => v.Villa_Number == villaNumberId)
            };
            if (villaNumberVM.VillaNumber == null)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(villaNumberVM);
        }
        [HttpPost]
        public IActionResult Delete(VillaNumberVM obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.VillaNumber.Remove(obj.VillaNumber);
                _unitOfWork.Save();
                TempData["success"] = "The villa has been created successfully";
                return RedirectToAction("Index", "VillaNumber");
            }
            if (_unitOfWork.VillaNumber.Any(v => v.Villa_Number == obj.VillaNumber.Villa_Number))
            {
                TempData["error"] = "The villa has not been created";

            }
            return View(obj);
        }
    }

}
