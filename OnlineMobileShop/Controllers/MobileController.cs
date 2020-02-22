using System.Collections.Generic;
using OnlineMobileShop.Entity;
using OnlineMobileShop.Respository;
using System.Web.Mvc;
using System.Data;

namespace OnlineMobileShop.Controllers
{  
    public class MobileController : Controller
    {
        // GET: Mobile
        MobileRespository repository = new MobileRespository();
        public ActionResult RunMaster()
        {
            return View();
        }
        public ActionResult MobileDetails()
        {
            
            DataTable mobile = repository.GetDetails();
            ViewBag.Mobile = mobile;
            ViewData["mobile"] = mobile;
            TempData["mobile"] = mobile;
            return RedirectToAction("DisplayDetails");
        }
        public ActionResult DisplayDetails()
        {
           DataTable mobilelist = repository.GetDetails();
            return View(mobilelist);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create_post()
        {
            Mobile mobile = new Mobile();
            UpdateModel<Mobile>(mobile);
            repository.Add(mobile);
            TempData["Message"] = "Added";
            return RedirectToAction("MobileDetails");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Mobile mobile = MobileRespository.GetMobileID(id);
            return View(mobile);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            MobileRespository.Delete(id);
            return RedirectToAction("MobileDetails");
        }
        [HttpPost]
        public ActionResult Update()
        {
            Mobile mobile = new Mobile();
            TryUpdateModel<Mobile>(mobile);
            MobileRespository.Update(mobile);
            return RedirectToAction("MobileDetails");


        }

    }
}
