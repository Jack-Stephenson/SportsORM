using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsORM.Models;


namespace SportsORM.Controllers
{
    public class HomeController : Controller
    {

        private static Context _context;

        public HomeController(Context DBContext)
        {
            _context = DBContext;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.BaseballLeagues = _context.Leagues
                .Where(l => l.Sport.Contains("Baseball"))
                .ToList();
            return View();
        }

        [HttpGet("level_1")]
        public IActionResult Level1()
        {
            ViewBag.WomensLeagues = _context.Leagues
                .Where(league => league.Name.Contains("Women"))
                .ToList();
            ViewBag.HockeyLeagues = _context.Leagues
                .Where(league => league.Sport.Contains("Hockey"))
                .ToList();
            ViewBag.NotFootballLeagues = _context.Leagues
                .Where(league => !league.Sport.Contains("Football"))
                .ToList();
            ViewBag.ConferenceLeagues = _context.Leagues
                .Where(league => league.Name.Contains("Conference"))
                .ToList();
            ViewBag.AtlanticLeagues = _context.Leagues
                .Where(league => league.Name.Contains("Atlantic"))
                .ToList();
            ViewBag.DallasTeams = _context.Teams
                .Where(team => team.Location.Contains("Dallas"))
                .ToList();
            ViewBag.RaptorsTeams = _context.Teams
                .Where(team => team.TeamName.Contains("Raptors"))
                .ToList();
            ViewBag.CityTeams = _context.Teams
                .Where(league => league.Location.Contains("City"))
                .ToList();
            ViewBag.TTeams = _context.Teams
                .Where(league => league.TeamName.StartsWith("T"))
                .ToList();
            ViewBag.AlphabetTeams = _context.Teams
                .OrderBy(team => team.Location)
                .ToList();
            ViewBag.ReverseAlphabetTeams = _context.Teams
                .OrderByDescending(team=>team.Location)
                .ToList();
            ViewBag.CooperPlayers = _context.Players
                .Where(league => league.LastName.Contains("Cooper"))
                .ToList();
            ViewBag.JoshuaPlayers = _context.Players
                .Where(league => league.FirstName.Contains("Joshua"))
                .ToList();
            ViewBag.NotJoshuaCooperPlayers = _context.Players
                .Where(league => league.LastName.Contains("Cooper") && !league.FirstName.Contains("Joshua"))
                .ToList();
            ViewBag.AlexanderWyattPlayers = _context.Players
                .Where(league => league.FirstName.Contains("Alexander") || league.FirstName.Contains("Wyatt"))
                .ToList();
            
            return View();
        }

        [HttpGet("level_2")]
        public IActionResult Level2()
        {
            return View();
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            return View();
        }

    }
}