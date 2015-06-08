using System;
using System.Web.Mvc;
using System.Web.Security;
using PlaceNetwork.BusinessLogic.Services.Interfaces;
using PlaceNetwork.Data.Models;
using PlaceNetwork.Models;

namespace PlaceNetwork.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserLoginModel userLoginModel)
        {
            if (ModelState.IsValid)
            {      
                if (IsValid(userLoginModel.Login, userLoginModel.Password))
                {
                    var user = _userService.GetByLogin(userLoginModel.Login);
                    var username = user.Username;
                    var id = user.Id;
                    FormsAuthentication.SetAuthCookie(username, false);
                    FormsAuthentication.SetAuthCookie(id.ToString(), false);
                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Login data is incorrect");
            }
            return View(userLoginModel);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserRegistrationModel userRegistrationModel)
        {

            if (ModelState.IsValid)
            {
                var loginCheck = _userService.GetByLogin(userRegistrationModel.Login);
                var emailCheck = _userService.GetByEmail(userRegistrationModel.Email);
                var userNameCheck = _userService.GetByUsername(userRegistrationModel.UserName);

                if (loginCheck == null && emailCheck == null && userNameCheck == null)
                {
                    var crypto = new SimpleCrypto.PBKDF2();
                    var salt = crypto.GenerateSalt();
                    var hashedPass = crypto.Compute(userRegistrationModel.Password, salt);

                    var user = new User
                    {
                        DateRegistered = DateTime.Today,
                        Email = userRegistrationModel.Email.ToLower(),
                        Username = userRegistrationModel.UserName,
                        Login = userRegistrationModel.Login,
                        PasswordHash = hashedPass,
                        PasswordSalt = salt
                    };

                    _userService.Add(user);
                    var loginModel = new UserLoginModel
                    {
                        Login = userRegistrationModel.Login,
                        Password = userRegistrationModel.Password
                    };
                    return Login(loginModel);
                }
                else
                {
                    if (loginCheck != null)
                        ModelState.AddModelError("", "Login already exists.");
                    if (emailCheck != null)
                        ModelState.AddModelError("", "Email address has a profile already.");
                    if (userNameCheck != null)
                        ModelState.AddModelError("", "User name already exists.");
                }
            }
            else
                ModelState.AddModelError("", "Data is incorrect.");
            return View();
        }


        [NonAction]
        private bool IsValid(string login, string password)
        {
            var isValid = false;
            var crypto = new SimpleCrypto.PBKDF2();
            var user = _userService.GetByLogin(login);
            if (user != null && user.PasswordHash == crypto.Compute(password, user.PasswordSalt))
                isValid = true;
            return isValid;
        }
    }
}