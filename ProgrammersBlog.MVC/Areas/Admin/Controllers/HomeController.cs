﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProgrammersBlog.MVC.Models;

namespace ProgrammersBlog.MVC.Areas.Admin.Controllers {
	[Area("Admin")]
	public class HomeController : Controller {

		public IActionResult Index() {
			return View();
		}

	}
}
