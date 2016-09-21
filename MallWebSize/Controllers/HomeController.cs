using MallLogic;
using MallWebSize.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MallWebSize.Controllers
{
    public class HomeController : Controller
    {
        
        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            GoodsInfoModel model = new GoodsInfoModel();
            GoodsLogic goodsLogic=new GoodsLogic();
            var categoryList = goodsLogic.GetCategory();
            var goodsList = goodsLogic.GetGoodsList();
            model.DirectoryList = categoryList;
            model.GoodsList = goodsList;
            ViewBag.Category = categoryList.Where(m => m.Rank == 0).ToList();
            return View(model);
        }
        public string KeepAlive()
        {
            return "success";
        }
        /// <summary>
        /// 苹果列表
        /// </summary>
        /// <returns></returns>
        public ActionResult AppleList(Guid guid) 
        {
            GoodsLogic goodsLogic = new GoodsLogic();
            var categoryList = goodsLogic.GetCategoryByRank(0);
            ViewBag.Category = categoryList;
            ViewBag.Title = "苹果列表";
            var apples = goodsLogic.GetGoodsList(guid);
            return View(apples);
        }

        /// <summary>
        /// 葡萄列表
        /// </summary>
        /// <returns></returns>
        public ActionResult PutaoList(Guid guid)
        {
            GoodsLogic goodsLogic = new GoodsLogic();
            var categoryList = goodsLogic.GetCategoryByRank(0);
            ViewBag.Category = categoryList;
            ViewBag.Title = "葡萄列表";
            var grapes = goodsLogic.GetGoodsList(guid);
            return View(grapes);
        }

        public ActionResult GoodDetail(Guid goodGuid) 
        {
             GoodsLogic goodsLogic=new GoodsLogic();
             var categoryList = goodsLogic.GetCategoryByRank(0);
             ViewBag.Category = categoryList;
             var good = goodsLogic.GetGoodDetaile(goodGuid);
             ViewBag.Title = good.GoodsName;
             return View(good);
        }
    }
}
