using MallLogic;
using MallLogic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MallWebSize.Controllers
{
    public class BusinessController : Controller
    {
        //
        // GET: /Business/

        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UploadFile(string picString)
        {
            bool isOk = false;
            string msg = string.Empty;
            picString = picString.Split(',')[1];
            isOk = CommonLogic.UploadFile(picString, out msg);
            return Json(new { suc = isOk, msg = msg });
        }


    }
}
