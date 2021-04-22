using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xc.Tonglian.Web.Controllers
{
    public class UserController : Controller
    {

        private TonglianDbContext _dbContext;

        private readonly IMapper _mapper;

        public UserController(TonglianDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult DoLogin()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult DoRegister()
        {
            return View();
        }
    }
}
