﻿using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Models.DTOs;
using BusinessLayer.Models.VMs;
using DataAccessLayer.IRepositories;
using DataAccessLayer.Repositories;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BusinessLayer.Services.AppUserService
{
    public class AppUserService : IAppUserService
    {
       

        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;//cookie olayları yöneticek
        private readonly RoleManager<AppRole> roleManager;
        private readonly IMapper mapper;
        private readonly IAppUserRepository appUserRepository;

        public AppUserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IMapper mapper, IAppUserRepository appUserRepository)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.mapper = mapper;
            this.appUserRepository = appUserRepository;
        }

        public async Task SifreOlustur()
        {
            List<AppUser> userList = new List<AppUser>();
            userList = await GetAllUsersAppUser();

            //List<AppUser> appUserList = new List<AppUser>();
            //appUserList = mapper.Map<List<AppUserVM>, List<AppUser>>(userList);


            foreach (AppUser user in userList)
            {
                string password = user.FirstName + "123Aa!";
                user.PasswordHash = userManager.PasswordHasher.HashPassword(user, password);
                IdentityResult result = await userManager.UpdateAsync(user);

            }
                        
        }

        public async Task<List<AppUser>> GetAllUsersAppUser()
        {
            var users = await appUserRepository.GetFilteredList(
                selector: x => new AppUser
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    SecondName = x.SecondName,
                    LastName = x.LastName,
                    TCNO = x.TCNO,
                    ImagePath = x.ImagePath,
                    Gender = x.Gender,
                    BirthDate = x.BirthDate,
                    Address = x.Address,
                    Status = x.Status,
                    Title = x.Title,
                    EmploymentDate = x.EmploymentDate,
                    AnnualLeave = x.AnnualLeave,
                    GrossSalary = x.GrossSalary,
                    DepartmentID = x.DepartmentID,
                    UserName = x.UserName,
                    NormalizedUserName = x.NormalizedUserName,
                    Email = x.Email,
                    NormalizedEmail = x.NormalizedEmail,
                    EmailConfirmed = x.EmailConfirmed,
                    PasswordHash = x.PasswordHash,
                    SecurityStamp = x.SecurityStamp,
                    ConcurrencyStamp = x.ConcurrencyStamp,
                    PhoneNumber = x.PhoneNumber,
                    PhoneNumberConfirmed = x.PhoneNumberConfirmed,
                    TwoFactorEnabled = x.TwoFactorEnabled,
                    LockoutEnd = x.LockoutEnd,
                    LockoutEnabled = x.LockoutEnabled,
                    AccessFailedCount = x.AccessFailedCount

                },
                expression: x => x.FirstName != null,
                orderBy: x => x.OrderBy(x => x.FirstName),
                includes: x => x.Include(x => x.Department)
                );

            return users;
        }



        public async Task<SignInResult> LogIn(LoginDTO model)
        {

            var result = await signInManager.PasswordSignInAsync("jane.doe", model.Password, false, false);
            return result;



            //AppUser user = await userManager.FindByEmailAsync(model.Email);

            //var result = await signInManager.PasswordSignInAsync(user.UserName, model.Password, false, false);

            //return result;
        }



        public async Task<bool> CheckRole(string name, string role)
        {
            AppUser user = await userManager.FindByNameAsync(name);

            List<AppRole> allRoles = roleManager.Roles.ToList();
            List<string> userRoles = await userManager.GetRolesAsync(user) as List<string>;
            
            //var searchedRole = roleManager.FindByNameAsync(role).Result;
            bool userIsInRole = await userManager.IsInRoleAsync(user, role);
            if ( userIsInRole == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task LogOut()
        {
            await signInManager.SignOutAsync();
        }

        public Task<bool> Any(Expression<Func<AppUserUpdateDTO, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task Create(AppUserUpdateDTO user)
        {
            var createUser = mapper.Map<AppUser>(user);
            createUser.Status = true;

            await appUserRepository.Create(createUser);

        }

        public Task Delete(AppUserUpdateDTO entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<AppUserVM>> GetAllBirthDayEmployees()
        {
            var users = await appUserRepository.GetFilteredList(
                selector: x => new AppUserVM
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    SecondName = x.SecondName,
                    LastName = x.LastName,
                    ImagePath = x.ImagePath,
                    Gender = x.Gender,
                    Title = x.Title,
                    Department = x.Department,
                    BirthDate = x.BirthDate,
                    Status = x.Status

                },
                expression: x => x.Status == true && x.BirthDate.Month == DateTime.Now.Month && x.BirthDate.Day >= DateTime.Now.Day,
                orderBy: x => x.OrderBy(x => x.BirthDate.Day)
                );

            return users;
        }
        public async Task<List<AppUserVM>> GetAllUsers()
        {
            var users = await appUserRepository.GetFilteredList(
                selector: x => new AppUserVM
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    SecondName = x.SecondName,
                    LastName = x.LastName,
                    ImagePath = x.ImagePath,
                    Gender = x.Gender,
                    Title = x.Title,
                    Department = x.Department

                },
                expression: x => x.FirstName != null,
                orderBy: x => x.OrderBy(x => x.FirstName),
                includes: x => x.Include(x => x.Department)
                );

            return users;
        }





        public Task<List<AppUserUpdateDTO>> GetAllWhere(Expression<Func<AppUserUpdateDTO, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task<AppUserDetailsVM> GetById(int id)
        {
            var user = await appUserRepository.GetFilteredFirstOrDefault(
                selector: x => new AppUserDetailsVM
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    SecondName = x.SecondName,
                    LastName = x.LastName,
                    Department = x.Department,
                    TCNO = x.TCNO,
                    Gender = x.Gender,
                    BirthDate = x.BirthDate,
                    EmploymentDate = x.EmploymentDate,
                    AnnualLeave = x.AnnualLeave,
                    Address = x.Address,
                    Title = x.Title,
                    ImagePath = x.ImagePath,
                    PhoneNumber = x.PhoneNumber


                },
                expression: x => x.Id == id && x.Status == true);
            return user;
            //
        }

        public async Task<AppUserDetailsVM> GetByName(string userName)
        {
            var user = await appUserRepository.GetFilteredFirstOrDefault(
                selector: x => new AppUserDetailsVM
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    SecondName = x.SecondName,
                    LastName = x.LastName,
                    Department = x.Department,
                    TCNO = x.TCNO,
                    Gender = x.Gender,
                    BirthDate = x.BirthDate,
                    EmploymentDate = x.EmploymentDate,
                    AnnualLeave = x.AnnualLeave,
                    Address = x.Address,
                    Title = x.Title,
                    ImagePath = x.ImagePath,
                    PhoneNumber = x.PhoneNumber


                },
                expression: x => x.UserName == userName && x.Status == true);
            return user;
            //
        }

        public async Task<AppUserUpdateDTO> GetByIdDTO(int id)
        {
            var user = await appUserRepository.GetFilteredFirstOrDefault(
                selector: x => new AppUserUpdateDTO
                {
                    Id = x.Id
                },
                expression: x => x.Id == id && x.Status == true);
            return user;
            //
        }

        public Task<TResult> GetFilteredFirstOrDefault<TResult>(Expression<Func<AppUserUpdateDTO, TResult>> selector, Expression<Func<AppUserUpdateDTO, bool>> expression, Func<IQueryable<AppUserUpdateDTO>, IOrderedQueryable<AppUserUpdateDTO>> orderBy = null, Func<IQueryable<AppUserUpdateDTO>, IIncludableQueryable<AppUserUpdateDTO, object>> includes = null)
        {
            throw new NotImplementedException();
        }

        public Task<List<TResult>> GetFilteredList<TResult>(Expression<Func<AppUserUpdateDTO, TResult>> selector, Expression<Func<AppUserUpdateDTO, bool>> expression, Func<IQueryable<AppUserUpdateDTO>, IOrderedQueryable<AppUserUpdateDTO>> orderBy = null, Func<IQueryable<AppUserUpdateDTO>, IIncludableQueryable<AppUserUpdateDTO, object>> includes = null)
        {
            throw new NotImplementedException();
        }

        public Task<AppUserUpdateDTO> GetWhere(Expression<Func<AppUserUpdateDTO, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public void StatusChange(AppUserUpdateDTO appUser)
        {
            throw new NotImplementedException();
        }

        public void Update(AppUserUpdateDTO user)
        {
            var updateUser = mapper.Map<AppUser>(user);
            updateUser.Status = !updateUser.Status;
            appUserRepository.Update(updateUser);
        }
        //public void StatusChange(AppUser appUser)
        //{
        //    appUser.Status = !appUser.Status;
        //    _appDbContext.Entry<AppUser>(appUser).State = EntityState.Modified;
        //    _appDbContext.SaveChanges();
        //}

        //public void StatusCreate(AppUser appUser)
        //{
        //    appUser.Status = true;
        //    _appDbContext.Entry<AppUser>(appUser).State = EntityState.Added;
        //    _appDbContext.SaveChanges();
        //}

    }
}
