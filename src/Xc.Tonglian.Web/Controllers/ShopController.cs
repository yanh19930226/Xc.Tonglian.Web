using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xc.Tonglian.Web.Models.Domain;
using Xc.Tonglian.Web.Models.Dto.Shop;

namespace Xc.Tonglian.Web.Controllers
{
    public class ShopController : Controller
    {
        private TonglianDbContext _dbContext;
        private readonly IMapper _mapper;
        public ShopController(TonglianDbContext dbContext, IMapper mapper)
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

            //var dtoss = _mapper.Map<Shop>(dto);

            //_dbContext.Shops.Add(dtoss);

            _dbContext.Shops.Add(new Shop()
            {
                StId = dto.StId,
                Platform = dto.Platform,
                Currency = dto.Currency,
                Exists = dto.Exists,
                SellerId = dto.SellerId,
                Monthamt = dto.Monthamt,
                Owner = dto.Owner,
                StoreName = dto.StoreName,
                Weburl = dto.Weburl,
                Categroy = dto.Categroy,
                Runtime = dto.Runtime,
                AuthToken = dto.AuthToken,
            });
            if (_dbContext.SaveChanges()>0)
            {
                result.Success("添加成功");
            }
            return Ok(result);
        }

        public ActionResult Edit(int Id)
        {
            var edit = _dbContext.Shops.Where(p => p.Id == Id).FirstOrDefault();
            ShopEditDto dto = new ShopEditDto();
            dto.StId = edit.StId;
            dto.Platform = edit.Platform;
            dto.Currency = edit.Currency;
            dto.Exists = edit.Exists;
            dto.SellerId = edit.SellerId;
            dto.Monthamt = edit.Monthamt;
            dto.Owner = edit.Owner;
            dto.StoreName = edit.StoreName;
            dto.Weburl = edit.Weburl;
            dto.Categroy = edit.Categroy;
            dto.Runtime = edit.Runtime;
            dto.AuthToken = edit.AuthToken;
            return View(dto);
        }

        [HttpPost]
        public IActionResult DoEdit(ShopEditDto dto)
        {
            TonglianResult result = new TonglianResult();
            var edit = _dbContext.Shops.Where(p => p.Id == dto.Id).FirstOrDefault();
            edit.StId = dto.StId;
            edit.Platform = dto.Platform;
            edit.Currency = dto.Currency;
            edit.Exists = dto.Exists;
            edit.SellerId = dto.SellerId;
            edit.Monthamt = dto.Monthamt;
            edit.Owner = dto.Owner;
            edit.StoreName = dto.StoreName;
            edit.Weburl = dto.Weburl;
            edit.Categroy = dto.Categroy;
            edit.Runtime = dto.Runtime;
            edit.AuthToken = dto.AuthToken;
            _dbContext.Shops.Update(edit);
            if (_dbContext.SaveChanges() > 0)
            {
                result.Success("修改成功");
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
            return Ok(result);
        }
    }
}
