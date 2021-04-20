using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xc.Tonglian.Web.Models.Domain;
using Xc.Tonglian.Web.Models.Dto.Account;

namespace Xc.Tonglian.Web.Controllers
{
    public class AccountController : Controller
    {
        private TonglianDbContext _dbContext;
        private readonly IMapper _mapper;
        public AccountController(TonglianDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
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
            _dbContext.Accounts.Add(new Account()
            {
                CusId = dto.CusId,
                AccountNo = dto.AccountNo,
                Currency = dto.Currency,
                AccountName = dto.AccountName,
                Nature = dto.Nature,
                Country = dto.Country,
                Province = dto.Province,
                City = dto.City,
                CardorBook = dto.CardorBook,
                BicCode = dto.BicCode,
                Addr = dto.Addr
            });
            if (_dbContext.SaveChanges() > 0)
            {
                result.Success("添加成功");
            }
            return Ok(result);
        }

        public ActionResult Edit(int Id)
        {
            var edit = _dbContext.Accounts.Where(p => p.Id == Id).FirstOrDefault();
            AccountEditDto dto = new AccountEditDto();
            dto.Id = edit.Id;
            dto.CusId = edit.CusId;
            dto.AccountNo = edit.AccountNo;
            dto.Currency = edit.Currency;
            dto.AccountName = edit.AccountName;
            dto.Nature = edit.Nature;
            dto.Country = edit.Country;
            dto.Province = edit.Province;
            dto.City = edit.City;
            dto.CardorBook = edit.CardorBook;
            dto.BicCode = edit.BicCode;
            dto.Addr = edit.Addr;
            return View(dto);
        }

        [HttpPost]
        public IActionResult DoEdit(AccountEditDto dto)
        {
            TonglianResult result = new TonglianResult();
            var edit = _dbContext.Accounts.Where(p => p.Id == dto.Id).FirstOrDefault();
            edit.CusId = dto.CusId;
            edit.AccountNo = dto.AccountNo;
            edit.Currency = dto.Currency;
            edit.AccountName = dto.AccountName;
            edit.Nature = dto.Nature;
            edit.Country = dto.Country;
            edit.Province = dto.Province;
            edit.City = dto.City;
            edit.CardorBook = dto.CardorBook;
            edit.BicCode = dto.BicCode;
            edit.Addr = dto.Addr;
            _dbContext.Accounts.Update(edit);
            if (_dbContext.SaveChanges() > 0)
            {
                result.Success("修改成功");
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
