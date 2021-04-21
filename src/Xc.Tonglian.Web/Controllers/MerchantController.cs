using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xc.Tonglian.Web.Models.Domain;
using Xc.Tonglian.Web.Models.Dto.Merchant;
using Xc.Tonglian.Web.Services;

namespace Xc.Tonglian.Web.Controllers
{
    public class MerchantController : Controller
    {
        private TonglianDbContext _dbContext;
        private readonly IMapper _mapper;
        private IMerchantService _merchantService;
        public MerchantController(TonglianDbContext dbContext, IMapper mapper, IMerchantService merchantService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _merchantService = merchantService;
        }
        public ActionResult Index()
        {
            return View();
        }

        public IActionResult DoList()
        {
            var result = _dbContext.Merchants.Where(p => p.IsDel == false).ToList();

            return PartialView(result);

        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DoAdd(MerchantCreateDto dto)
        {
            TonglianResult result = new TonglianResult();

            var res = _merchantService.CreateMerchant(dto);

            if (res.rspcode == "0000")
            {
                _dbContext.Merchants.Add(_mapper.Map<Merchant>(dto));

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

            _dbContext.Merchants.Add(_mapper.Map<Merchant>(dto));
           
            
            return Ok(result);

        }

        public ActionResult Edit(int Id)
        {
            var edit = _dbContext.Merchants.Where(p => p.Id == Id).FirstOrDefault();
           
            return View(_mapper.Map<MerchantEditDto>(edit));
        }

        [HttpPost]
        public IActionResult DoEdit(MerchantEditDto dto)
        {
            TonglianResult result = new TonglianResult();

            var res = _merchantService.EditMerchant(dto);

            if (res.rspcode == "0000")
            {
                var edit = _dbContext.Merchants.Where(p => p.Id == dto.Id).AsNoTracking().FirstOrDefault();

                edit = _mapper.Map<Merchant>(dto);

                _dbContext.Merchants.Update(edit);

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
            var delete = _dbContext.Merchants.Where(p => p.Id == Id).FirstOrDefault();
            delete.IsDel = true;
            _dbContext.Merchants.Update(delete);
            if (_dbContext.SaveChanges() > 0)
            {
                result.Success("删除成功");
            }
            return Ok(result);
        }
    }
}
