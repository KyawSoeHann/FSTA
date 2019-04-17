using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FSTA.DAO;
using FSTA.Models;

namespace FSTA.Controllers
{
    public class CostController : Controller
    {
        // GET: Cost
        public ActionResult Index()
        {
            List<Leader> leaders = LeaderDao.getAllLeaders();
            ViewData["LeaderList"] = leaders;
            return View();
        }
        public ActionResult Cost(int leaderId,int noOfDays)
        {
            Leader l = LeaderDao.getLeaderById(leaderId);
            int cost = l.getTotalRate(noOfDays);
            return Json(cost, JsonRequestBehavior.AllowGet);
        }
    }
}