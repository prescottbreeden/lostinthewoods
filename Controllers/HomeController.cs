using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using lost_in_the_woods.Models;
using lost_in_the_woods.Factories;

namespace lost_in_the_woods.Controllers
{
    public class HomeController : Controller
    {
        private readonly TrailFactory trailFactory;
        public HomeController(DbConnector connect)
        {
            trailFactory = new TrailFactory();
        }
        
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.allTrails = trailFactory.GetAllTrails();
            return View();
        }
        [HttpGet]
        [Route("NewTrail")]
        public IActionResult NewTrail()
        {
            return View("NewTrail");
        }

        [HttpPost]
        [Route("/AddTrail")]
        public IActionResult AddNewTrail(Trail trail)
        {
            if(trail.Length == 0 || trail.Elevation == 0)
            {
                ViewBag.errors = "Values cannot be 0 for Length and Elevation";
                return View("NewTrail");
            }
            trailFactory.AddNewTrail(trail);
            
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("trails/{id}")]
        public IActionResult ShowTrail(int id)
        {
            ViewBag.trail = trailFactory.GetTrailId(id);
            return View("Trail");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
