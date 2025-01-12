namespace Projekt1.Controllers;

using Microsoft.AspNetCore.Mvc;
using Projekt1.Models;

public class TournamentController : Controller
    {
        private static Tournament _tournament;

        public TournamentController()
        {
            if (_tournament == null)
            {
                _tournament = new Tournament();
                Data data = new Data();
                List<Team> teams = data.Teams;

                foreach (var team in teams)
                {
                    _tournament.AddTeamFirstCycle(team);
                }
            }
        }

        public IActionResult Index()
        {
            return View(_tournament);
        }

        public IActionResult StartTournament()
        {
            _tournament.StartTournament();
            return RedirectToAction("Results");
        }

        public IActionResult Results()
        {
            return View(_tournament.Winners);
        }
    }
