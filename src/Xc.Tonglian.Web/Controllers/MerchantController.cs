using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xc.Tonglian.Web.Models.Domain;
using Xc.Tonglian.Web.Models.Dto.Merchant;

namespace Xc.Tonglian.Web.Controllers
{
    public class MerchantController : Controller
    {
        private TonglianDbContext _dbContext;
        private readonly IMapper _mapper;
        public MerchantController(TonglianDbContext dbContext, IMapper mapper)
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

            _dbContext.Merchants.Add(new Merchant()
            {
                RegId = dto.RegId,
                CusId = dto.CusId,
                MerName = dto.MerName,
                AreaCode = dto.AreaCode,
                OrganId = dto.OrganId,
                Products = dto.Products,
            });
            if (_dbContext.SaveChanges() > 0)
            {
                result.Success("添加成功");
            }
            return Ok(result);
        }

        public ActionResult Edit(int Id)
        {
            var edit = _dbContext.Merchants.Where(p => p.Id == Id).FirstOrDefault();
            MerchantEditDto dto = new MerchantEditDto();
            dto.RegId = edit.RegId;
            dto.CusId = edit.CusId;
            dto.MerName = edit.MerName;
            dto.AreaCode = edit.AreaCode;
            dto.OrganId = edit.OrganId;
            dto.Products = edit.Products;
            return View(dto);
        }

        [HttpPost]
        public IActionResult DoEdit(MerchantEditDto dto)
        {
            TonglianResult result = new TonglianResult();
            var edit = _dbContext.Merchants.Where(p => p.Id == dto.Id).FirstOrDefault();
            edit.RegId = dto.RegId;
            edit.CusId = dto.CusId;
            edit.MerName = dto.MerName;
            edit.AreaCode = dto.AreaCode;
            edit.OrganId = dto.OrganId;
            edit.Products = dto.Products;
            _dbContext.Merchants.Update(edit);
            if (_dbContext.SaveChanges() > 0)
            {
                result.Success("修改成功");
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
