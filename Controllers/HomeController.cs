﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GuessGame.Models;
using Microsoft.AspNetCore.Http;
using GuessGame.Database;

namespace GuessGame.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        



        public IActionResult Privacy()
        {
            return View();
        }
        
        public IActionResult TermsOfService()
        {
            return View();
        }
        
        public IActionResult About()
        {
            return View();
        }
        
        public IActionResult TheGame()
        {
            return View();
        }
        
        public IActionResult ActiveGame()
        {
            return View();
        }
        
        public IActionResult MyPage()
        {
            return View();
        }
        public IActionResult PreviousGame()
        {
            return View();
        }
        


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
