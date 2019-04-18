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
        public ActionResult Assign()
        {
            List<Tour> tLists = TourDao.getTourList();
            ViewData["TourList"] = tLists;
            List<Leader> leaders = LeaderDao.getAllLeaders();
            ViewData["LeaderList"] = leaders;

            return View();
        }
        public ActionResult AssignLeader(int leaderId, int tourRef)
        {
            string msg = "";
            Leader l = LeaderDao.getLeaderById(leaderId);
            Tour t = TourDao.getTourById(tourRef);
            if (l.checkDestination(t.destination))
            {
                TourDao.UpdateLeader(leaderId, tourRef);
                msg = "Successfully assigned.";
            }
            else
            {
                msg = "Tour Leader could not be assigned.";
            }
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
    }
}