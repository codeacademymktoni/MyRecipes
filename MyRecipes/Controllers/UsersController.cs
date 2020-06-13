﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyRecipes.Custom;
using MyRecipes.Helpers;
using MyRecipes.Services.Interfaces;
using MyRecipes.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyRecipes.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        [Authorize(Policy = "IsAdmin")]
        public IActionResult ModifyUsersOverview()
        {
            var users = usersService.GetAll();

            var viewModels = new List<ModifyUserOverviewModel>();
            foreach (var user in users)
            {
                viewModels.Add(ModelConverter.ConvertToModifyUserOverview(user));
            }

            return View(viewModels);
        }

        public IActionResult Delete(int id)
        {
            if(!AuthorizeService.AuthorizeUser(User, id))
            {
                return RedirectToAction("Auth", "AccessDenied");
            }

            usersService.Delete(id);


            if(Convert.ToInt32(User.FindFirst("Id").Value) == id)
            {
                return RedirectToAction("SignOut", "Auth");
            }

            return RedirectToAction("SuccessfulUserChange");
        }

        public IActionResult Modify(int id)
        {
            if (!AuthorizeService.AuthorizeUser(User, id))
            {
                return RedirectToAction("Auth", "AccessDenied");
            }

            var user = usersService.GetById(id);
            var modifyUser = ModelConverter.ConvertToUserModifyModel(user);
            return View(modifyUser);
        }


        [HttpPost]
        public IActionResult Modify(UserModifyModel userModifyModel)
        {
            if (!AuthorizeService.AuthorizeUser(User, userModifyModel.Id))
            {
                return RedirectToAction("Auth", "AccessDenied");
            }

            if (ModelState.IsValid)
            {
                var user = ModelConverter.ConvertFromUserModifyModel(userModifyModel);
                var result = usersService.ModifyUser(user);

                if (result.Status)
                {
                    return RedirectToAction("SuccessfulUserChange");
                }
                else
                {
                    ModelState.AddModelError("", result.Message);
                }
            }

            return View(userModifyModel);
        }

        public IActionResult ChangePassword(int id)
        {
            if (!AuthorizeService.AuthorizeUser(User, id))
            {
                return RedirectToAction("Auth", "AccessDenied");
            }

            var model = new UserChangePassModel();
            model.Id = id;
            return View(model);
        }

        [HttpPost]
        public IActionResult ChangePassword(UserChangePassModel userChangePassModel)
        {
            if (!AuthorizeService.AuthorizeUser(User, userChangePassModel.Id))
            {
                return RedirectToAction("Auth", "AccessDenied");
            }

            if (ModelState.IsValid)
            {
                usersService.ChangePassword(userChangePassModel.Id, userChangePassModel.Password);
                return RedirectToAction("SuccessfulUserChange");
            }

            return View(userChangePassModel);
        }

        [Authorize(Policy = "IsAdmin")]
        public IActionResult Create()
        {
            var user = new CreateUserModel();
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "IsAdmin")]
        public IActionResult Create(CreateUserModel createUserModel)
        {
            if (ModelState.IsValid)
            {
                var message = usersService.CreateUser(createUserModel.Username, createUserModel.Password, createUserModel.IsAdmin);

                if (String.IsNullOrEmpty(message))
                {
                    return RedirectToAction("SuccessfulUserChange");
                }
                else
                {
                    ModelState.AddModelError("", message);
                }
            }

            return View(createUserModel);
        }

        public IActionResult Details(int id)
        {
            if (!AuthorizeService.AuthorizeUser(User, id))
            {
                return RedirectToAction("Auth", "AccessDenied");
            }

            var user = usersService.GetById(id);
            var viewModel = ModelConverter.ConvertToUserDetailsModel(user);
            return View(viewModel);
        }

        public IActionResult SuccessfulUserChange()
        {
            return View();
        }
    }
}