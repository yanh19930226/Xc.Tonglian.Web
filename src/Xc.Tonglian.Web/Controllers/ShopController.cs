using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xc.Tonglian.Web.Models.Domain;
using Xc.Tonglian.Web.Models.Dto.Shop;
using Xc.Tonglian.Web.Services;

namespace Xc.Tonglian.Web.Controllers
{
    public class ShopController : Controller
    {
        private TonglianDbContext _dbContext;
        private readonly IMapper _mapper;
        private IMediator _mediator;
        private IShopService _shopService;

        public ShopController(TonglianDbContext dbContext, IMapper mapper, IMediator mediator,IShopService shopService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _mediator = mediator;
            _shopService = shopService;
        }
        public ActionResult Index()
        {
            return View();
        }

        public IActionResult DoList()
        {
            var result=_dbContext.Shops.Where(p=>p.IsDel==false).ToList();

            return PartialView(result);

        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult DoAdd(ShopCreateDto dto)
        {
            TonglianResult result = new TonglianResult();

            var res = _shopService.CreateShop(dto);

            if (res.sid!=null)
            {
                _dbContext.Shops.Add(_mapper.Map<Shop>(dto));

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
            var edit = _dbContext.Shops.Where(p => p.Id == Id).FirstOrDefault();

            return View(_mapper.Map<ShopEditDto>(edit));
        }

        [HttpPost]
        public IActionResult DoEdit(ShopEditDto dto)
        {
            TonglianResult result = new TonglianResult();

            var res = _shopService.EditShop(dto);

            if (res.sid !=null)
            {
                var edit = _dbContext.Shops.Where(p => p.Id == dto.Id).AsNoTracking().FirstOrDefault();

                edit = _mapper.Map<Shop>(dto);

                _dbContext.Shops.Update(edit);

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
            var delete = _dbContext.Shops.Where(p => p.Id == Id).FirstOrDefault();

            delete.IsDel = true;

            _dbContext.Shops.Update(delete);

            if (_dbContext.SaveChanges() > 0)
            {
                result.Success("删除成功");
            }
            else
            {
                result.Failed("删除失败");
            }
            return Ok(result);
        }
    }
}
