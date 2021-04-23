using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xc.Tonglian.Web.Models;
using Xc.Tonglian.Web.Models.Domain;
using Xc.Tonglian.Web.Models.Dto.User;

namespace Xc.Tonglian.Web.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly UserManager<User> _userManager;

        private readonly SignInManager<User> _signInManager;

        private TonglianDbContext _dbContext;

        public HomeController(UserManager<User> userManager, SignInManager<User> signInManager, TonglianDbContext dbContext)
        {
            _userManager = userManager;

            _signInManager = signInManager;

            _dbContext = dbContext;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {

            return View();
        }

        #region 登入登出

        public ActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> DoLogin(LoginDto dto, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(dto.Email);
                if (user != null)
                {
                    await _signInManager.SignInAsync(user, new AuthenticationProperties { IsPersistent = true });
                }
                return RedirectToLocal(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// 登出
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> LogOut()
        {

            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        #endregion


        #region 注册
        
        public IActionResult Register(string returnUrl = null)
        {
            ViewData[nameof(returnUrl)] = returnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DoRegister(RegisterDto dto, string returnUrl = null)
        {
            TonglianResult result = new TonglianResult();

            if (ModelState.IsValid)
            {
                var identityUser = new User
                {
                    Email = dto.Email,
                    UserName = dto.Email,
                    NormalizedUserName = dto.Email
                };
                var identityResult = await _userManager.CreateAsync(identityUser, dto.Password);
                if (identityResult.Succeeded)
                {
                    await _signInManager.SignInAsync(identityUser, new AuthenticationProperties { IsPersistent = true });

                    return RedirectToLocal(returnUrl);
                }
                else
                {
                    //AddErrors(identityResult);
                }
            }
            return Ok(result);
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Index", "Home");
        }
        #endregion
       
    }
}
