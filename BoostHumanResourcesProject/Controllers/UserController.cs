﻿using BusinessLayer.Abstract;
using BusinessLayer.Models.DTOs;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessLayer.Services.DepartmentService;
using System.Linq;
using BusinessLayer.Models.VMs;
using BusinessLayer.Validation;
using FluentValidation;
using FluentValidation.Results;

namespace BoostHumanResourcesProject.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IAppUserService appUserService;
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly IDepartmentService departmentService;

        public UserController(ILogger<UserController> logger, IAppUserService appUserService, IWebHostEnvironment hostingEnvironment, IDepartmentService departmentService)
        {
            _logger = logger;
            this.appUserService = appUserService;
            this.hostingEnvironment = hostingEnvironment;
            this.departmentService = departmentService;
        }

        public async Task<IActionResult> PersonList()
        {

            List<AppUserVM> appUserVMs = await appUserService.GetAllUsers();
            return View(appUserVMs);
        }
        [HttpGet]
        public async Task<IActionResult> AddUser()
        {
            List<GetDepartmentsVM> departmentValue = (from x in await departmentService.GetAllDepartments()
                                                      select new GetDepartmentsVM
                                                      {
                                                          DepartmentName = x.DepartmentName,
                                                          DepartmentID = x.DepartmentID
                                                      }).ToList();
            AppUserandDepartments appUserandDepartments = new AppUserandDepartments();
            AppUserUpdateDTO appUserUpdateDTO = new AppUserUpdateDTO();
            appUserandDepartments.appUserUpdateDTO = appUserUpdateDTO;
            appUserandDepartments.departmentsList = departmentValue;
            return View(appUserandDepartments);
        }
     
        [HttpPost]
        public async Task<IActionResult> AddUser(AppUserandDepartments user)
        {
            //AppUserUpdateDTO appUserUpdateDTO = new AppUserUpdateDTO();
            //appUserUpdateDTO = user.appUserUpdateDTO;
            //AppUserUpdateDTOValidator validationRules = new AppUserUpdateDTOValidator();
            //ValidationResult validationResult = validationRules.Validate(appUserUpdateDTO);
            if (ModelState.IsValid)
            {

                if (user.appUserUpdateDTO.file != null)
                {
                    var extension = Path.GetExtension(user.appUserUpdateDTO.file.FileName);
                    var newImageName = Guid.NewGuid() + extension;
                    string projectRootPath = hostingEnvironment.WebRootPath;
                    string uploadsFolder = Path.Combine(projectRootPath, "images");
                    string location = Path.Combine(uploadsFolder, newImageName);
                    using (var fileStream = new FileStream(location, FileMode.Create))
                    {
                        user.appUserUpdateDTO.file.CopyTo(fileStream);
                    }
                    user.appUserUpdateDTO.ImagePath = newImageName;
                }
                else
                {
                    user.appUserUpdateDTO.ImagePath = "pic-1.png";
                }
                
                await appUserService.Create(user.appUserUpdateDTO);
                return RedirectToAction("PersonList", "User");
            }
            //else
            //{
            //    foreach (var item in ModelState.Errors)
            //    {
            //        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            //    }
            //}
            List<GetDepartmentsVM> departmentValue = (from x in await departmentService.GetAllDepartments()
                                                      select new GetDepartmentsVM
                                                      {
                                                          DepartmentName = x.DepartmentName,
                                                          DepartmentID = x.DepartmentID
                                                      }).ToList();
            AppUserandDepartments appUserandDepartments = new AppUserandDepartments();
            
            appUserandDepartments.appUserUpdateDTO = user.appUserUpdateDTO;
            appUserandDepartments.departmentsList = departmentValue;
            return View(appUserandDepartments);
        }

        public async Task<IActionResult> UserDetails(int id)
        {

            AppUserDetailsVM appUserDetailsVM = await appUserService.GetById(id);
            return View(appUserDetailsVM);
        }

        public IActionResult StatusChange()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(AppUserUpdateDTO appUserUpdateDTO)
        {
            if (ModelState.IsValid)
            {
                AppUserUpdateDTO user = await appUserService.GetByIdDTO(appUserUpdateDTO.Id);


                if (user != null)
                {

                    user.FirstName = appUserUpdateDTO.FirstName;
                    user.LastName = appUserUpdateDTO.LastName;
                    user.Email = appUserUpdateDTO.Email;
                    user.TCNO = appUserUpdateDTO.TCNO;
                    user.BirthDate = appUserUpdateDTO.BirthDate;
                    user.Address = appUserUpdateDTO.Address;
                    user.Status = appUserUpdateDTO.Status;
                    user.Title = appUserUpdateDTO.Title;
                    user.GrossSalary = appUserUpdateDTO.GrossSalary;



                    string newImageName = String.Empty;  //to contain the filename
                    if (appUserUpdateDTO.file != null)  //handle iformfile
                    {

                        string projectRootPath = hostingEnvironment.WebRootPath;
                        string uploadsFolder = Path.Combine(projectRootPath, "images");
                        //string userFolder = Path.Combine(uploadsFolder, user.Id.ToString());
                        //if (!Directory.Exists(userFolder))
                        //{
                        //    Directory.CreateDirectory(userFolder);
                        //}
                        //else
                        //{
                        if (System.IO.File.Exists(Path.Combine(uploadsFolder, user.ImagePath)))
                        {
                            System.IO.File.Delete(Path.Combine(uploadsFolder, user.ImagePath));
                        }
                        //}
                        var extension = Path.GetExtension(appUserUpdateDTO.file.FileName);
                        newImageName = Guid.NewGuid() + extension;

                        string filePath = Path.Combine(uploadsFolder, newImageName);

                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            appUserUpdateDTO.file.CopyTo(fileStream);
                        }
                    }

                    user.ImagePath = newImageName;
                    HttpContext.Session.SetString("image", user.ImagePath);
                    appUserService.Update(user);
                }
                else
                {
                    ModelState.AddModelError("User Operations", "User not found");
                }
                return View(user);
            }
            else
            {
                return View(appUserUpdateDTO);
            }



        }
    }
}
