using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xc.Tonglian.Web.Models.Domain;
using Xc.Tonglian.Web.Models.Dto.Account;
using Xc.Tonglian.Web.Services;

namespace Xc.Tonglian.Web.Controllers
{

    [Authorize]
    public class AccountController : Controller
    {
        private TonglianDbContext _dbContext;

        private readonly IMapper _mapper;

        private IAccountService _accountService;

        public AccountController(TonglianDbContext dbContext, IMapper mapper, IAccountService accountService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _accountService = accountService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public IActionResult DoList()
        {
            var result = _dbContext.Accounts.Where(p => p.IsDel == false).ToList();

            return PartialView(result);

        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DoAdd(AccountCreateDto dto)
        {
            TonglianResult result = new TonglianResult();

            var res = _accountService.CreateAccount(dto);

            if (res.rspcode=="0000")
            {
                _dbContext.Accounts.Add(_mapper.Map<Account>(dto));

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
           
            return Ok(result);
        }

        public ActionResult Edit(int Id)
        {
            var edit = _dbContext.Accounts.Where(p => p.Id == Id).FirstOrDefault();

            return View(_mapper.Map<AccountEditDto>(edit));
            
        }

        [HttpPost]
        public IActionResult DoEdit(AccountEditDto dto)
        {
            TonglianResult result = new TonglianResult();

            var res = _accountService.EditAccount(dto);

            if (res.rspcode == "0000")
            {
                var edit = _dbContext.Accounts.Where(p => p.Id == dto.Id).AsNoTracking().FirstOrDefault();

                edit = _mapper.Map<Account>(dto);

                _dbContext.Accounts.Update(edit);

                if (_dbContext.SaveChanges() > 0)
                {
                    result.Success("修改成功");
                }
                else
                {
                    result.Failed("修改失败");
                }
            }
            else
            {
                result.Failed(res.rspinfo);
            }
           
            return Ok(result);
        }

        public IActionResult Delete(int Id)
        {
            TonglianResult result = new TonglianResult();

            var delete = _dbContext.Accounts.Where(p => p.Id == Id).FirstOrDefault();
            delete.IsDel = true;

            _dbContext.Accounts.Update(delete);

            if (_dbContext.SaveChanges() > 0)
            {
                result.Success("删除成功");
            }
            return Ok(result);
        }
    }
}
