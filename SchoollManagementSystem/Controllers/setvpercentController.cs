using SMS.Entities;
using SMS.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoollManagementSystem.Controllers
{
    public class setvpercentController : Controller
    {
        setVoucherpercentservice setVoucherpercentservice = new setVoucherpercentservice();
        // GET: setvpercent
        public ActionResult updateVPercent(int id)
        {
            
            var list=setVoucherpercentservice.getbyid(id);



            return View(list);
        }
        [HttpPost]
        public ActionResult updateVPercent(setVoucherpercent setVoucherpercent)
        {

            setVoucherpercentservice.updatesetVoucherpercent(setVoucherpercent);

            return View();
        }
    }
}