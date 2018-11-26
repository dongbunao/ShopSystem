using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopSystem.Controllers
{
    public class ProductController : Controller
    {
        private IBLL.IItemsService _itemsService = new ItemsService();
        // GET: Product
        public ActionResult Index(int id=0)
        {
            //Json格式的要求{total:22,rows:{}}

            //实现对用户分页的查询，rows：一共多少条，page：请求的当前第几页

            int pageIndex = Request["page"] == null ? 1 : int.Parse(Request["page"]);

            int pageSize = Request["rows"] == null ? 20 : int.Parse(Request["rows"]);

            int total = 0;

            //调用分页的方法，传递参数,拿到分页之后的数据

            var data = _itemsService.LoadPageEntities(pageIndex, pageSize, out total, u => u.UserID == id, true, u => u.ID);
            ViewData["data"] = data.ToList<Model.tb_Items>();
            ViewBag.userid = id;
            return View();
        }

        public ActionResult Edit(int id=0,int userid=0)
        {
            tb_Items model = new tb_Items();
            if (id > 0)
            {
                model = _itemsService.LoadEntities(x => x.ID == id).FirstOrDefault();
               
            }
            ViewData["item"] = model;
            ViewBag.userid = userid;
            return View();
        }

        public bool SaveEdit(tb_Items item)
        {
            bool result = _itemsService.UpdateEntity(item);
            return result;
        }
        public bool SaveAdd(tb_Items item)
        {
            tb_Items result = (tb_Items)_itemsService.AddEntity(item);
            if (result != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}