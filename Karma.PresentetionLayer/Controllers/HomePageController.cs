﻿using Microsoft.AspNetCore.Mvc;

namespace Karma.PresentetionLayer.Controllers
{
    public class HomePageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}