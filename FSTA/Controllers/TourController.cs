using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FSTA.DAO;
using FSTA.Models;

namespace FSTA.Controllers
{
    public class TourController : Controller
    {
        // GET: Tour
        public ActionResult Index()
        {
            List<Tour> tLists = TourDao.getTourList();

            ViewData["TourList"] = tLists;

            return View();
        }
    }
}