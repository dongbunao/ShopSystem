using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopSystem.Controllers
{
    public class HomeController : Controller
    {
        private IBLL.IItemsService _itemsService = new ItemsService();
        public ActionResult Index()
        {
            //Json格式的要求{total:22,rows:{}}

            //实现对用户分页的查询，rows：一共多少条，page：请求的当前第几页

            int pageIndex = Request["page"] == null ? 1 : int.Parse(Request["page"]);

            int pageSize = Request["rows"] == null ? 20 : int.Parse(Request["rows"]);

            int total = 0;

            //调用分页的方法，传递参数,拿到分页之后的数据

            var data = _itemsService.LoadPageEntities(pageIndex, pageSize, out total, u => true, true, u => u.ID);
            ViewData["data"] = data.ToList<Model.tb_Items>();
            return View();
        }
      
       
       
        public ActionResult About()
        {
           

            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}