﻿using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BoostHumanResourcesProject.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IAppUserService appUserService;


        public UserController(ILogger<UserController> logger, IAppUserService appUserService)
        {
            _logger = logger;
            this.appUserService = appUserService;
        }

        public IActionResult Index()
        {
            appUserService.GetById(1);
            return View();
        }
    }
}
