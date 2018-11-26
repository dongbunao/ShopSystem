using BLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopSystem.Controllers
{
    public class LoginController : Controller
    {

        private IBLL.ICustomerService _Service = new CustomerService();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public int Login_check(string name, string Password)
        {
            tb_Customer customer = new tb_Customer();
            customer = _Service.LoadEntities(x => x.Username == name && x.Password == Password).FirstOrDefault();
            if (customer != null)
            {
                return customer.ID;
            }
            else
            {
                return -1;
            }
           

        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public int AddCustomer(tb_Customer model)
        {
            tb_Customer newmodel= _Service.AddEntity(model);
            return newmodel.ID;
        }

    }
}