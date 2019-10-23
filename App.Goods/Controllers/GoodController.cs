using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using App.Models;

namespace App.Goods.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class GoodController: ControllerBase
    {
        readonly IGoodsManager _goodsManager;

        public GoodController(IGoodsManager goodsManager)
        {

            _goodsManager = goodsManager;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Good>> Get()
        {

            if (_goodsManager.GetGoods() == null)
                return NotFound();
            else
            {
                var serviceCallResult = _goodsManager.GetGoods().ToList();
                return serviceCallResult;
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Good> GetById(int id)
        {

            var serviceCallResult = _goodsManager.GetGood(id);
            return serviceCallResult;
        }
    }
}
