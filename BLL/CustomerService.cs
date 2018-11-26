using IBLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class CustomerService:BaseService<tb_Customer>,ICustomerService
    {
        public override void SetCurrentRepository()

        {

            CurrentRepository = DAL.RepositoryFactory.DALCustomer;

         }
}
}
