using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xc.Tonglian.Web.Controllers
{
    public class UserConfigController : Controller
    {
        private TonglianDbContext _dbContext;

        private readonly IMapper _mapper;

        public UserConfigController(TonglianDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DoList()
        {
            return View();
        }

        
        public ActionResult Add()
        {
            return View();
        }

       
        [HttpPost]
        public ActionResult DoAdd(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    
        public ActionResult Edit(int Id)
        {
            return View();
        }

       
        [HttpPost]
        public ActionResult DoEdit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    
        public ActionResult Delete(int Id)
        {
            return View();
        }
    
    }
}
