using Microsoft.AspNetCore.Mvc;
using GoFish.Models;
using System.Collections.Generic;
using System.Linq;
using System.Dynamic;

namespace GoFish.Controllers
{
    public class PlayerController : Controller
    {
        
        [HttpGet("/player")]
        public ActionResult Index()
        {
            return View(Game.Current.Players);
        }


        [HttpGet("/player/{playerone}")]
        public ActionResult Show(int playerone)
        {
            Player p = Game.Current.Players.Where(x => x.Id == playerone).ToList()[0];
            List<Player> l = Game.Current.Players.Where(x => x.Id != playerone).ToList();
            dynamic model = new ExpandoObject();
            model.List = l;
            model.Player = p;
            return View(model);
        }


        [HttpPost("/player/{playerone}")]
        public ActionResult Play(string rank, int playertwo, int playerone)
        {
            Player p = Game.Current.Players.Where(x => x.Id == playerone).ToList()[0];
            Player p2 = Game.Current.Players.Where(x => x.Id == playertwo).ToList()[0];
            p2.GiveCards(rank, p);
            
            return RedirectToAction("Show");
        }

    }
}