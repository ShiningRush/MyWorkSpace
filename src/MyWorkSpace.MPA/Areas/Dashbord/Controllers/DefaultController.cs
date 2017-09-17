using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyWorkSpace.Web.Areas.Dashbord.Controllers
{
    [Authorize(Policy = "baseAuth")]
    [Area("Dashbord")]
    public class DefaultController : Controller
    {
        // GET: Dashbord/Home
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Table()
        {
            return View();
        }

        public IActionResult Form()
        {
            return View();
        }

        public IActionResult PanelsAndWells()
        {
            return View();
        }

        public IActionResult Buttons()
        {
            return View();
        }

        public IActionResult Notifications()
        {
            return View();
        }

        public IActionResult Typography()
        {
            return View();
        }

        public IActionResult Icons()
        {
            return View();
        }

        public ActionResult Grid()
        {
            return View();
        }
    }
}