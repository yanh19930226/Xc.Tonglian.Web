using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xc.Tonglian.Web.Models.Domain;
using Xc.Tonglian.Web.Models.Dto.Customer;
using Xc.Tonglian.Web.Services;

namespace Xc.Tonglian.Web.Controllers
{
    public class CustomerController : Controller
    {
        private TonglianDbContext _dbContext;

        private readonly IMapper _mapper;

        private ICustomerService _customerService;

        public CustomerController(TonglianDbContext dbContext, IMapper mapper, ICustomerService customerService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _customerService = customerService;
        }
        public ActionResult Index()
        {
            return View();
        }

        public IActionResult DoList()
        {

            var result = _dbContext.Customers.Where(p => p.IsDel == false).ToList();

            return PartialView(result);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DoAdd(CustomerCreateDto dto)
        {
            TonglianResult result = new TonglianResult();

            var res = _customerService.CreateCustomer(dto);

            if (res.rspcode =="0000")
            {
                _dbContext.Customers.Add(_mapper.Map<Customer>(dto));

                if (_dbContext.SaveChanges() > 0)
                {
                    result.Success("添加成功");
                }
                else
                {
                    result.Failed("添加失败");
                }
            }
            else
            {
                result.Failed(res.rspinfo);
            }
            return Json(result);
        }

        public ActionResult Edit(int Id)
        {
            return View();
        }

        public ActionResult Detail(int Id)
        {
            var edit = _dbContext.Customers.Where(p => p.Id == Id).FirstOrDefault();

            return View(_mapper.Map<CustomerCreateDto>(edit));
        }

        [HttpPost]
        public IActionResult DoEdit()
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

        [HttpPost]
        public IActionResult Delete()
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
    }
}
