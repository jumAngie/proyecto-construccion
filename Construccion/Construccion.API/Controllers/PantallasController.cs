﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Construccion.API.Controllers
{
    public class PantallasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}