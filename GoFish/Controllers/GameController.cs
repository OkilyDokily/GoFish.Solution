using Microsoft.AspNetCore.Mvc;
using GoFish.Models;
using System.Linq;

namespace GoFish.Controllers
{
    public class GameController : Controller
    {
        [HttpPost("/")]
        public ActionResult New(int players)
        {
            if(Game.Current == null)
            {
                new Game(players);
            }
            return RedirectToAction("Index");
        }

        [HttpGet("/")]
        public ActionResult Index()
        {
            return View(Game.Current);
        }

   
    }
}