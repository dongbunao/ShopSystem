using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RepositoryFactory
    {
        public static IDALCustomer DALCustomer

        {

            get { return new DALCustomer(); }

        }

        public static IDALItems DALItems

        {

            get { return new DALItems(); }

        }

        public static DbContext GetCurrentDbContext()

        {

            //CallContext：是线程内部唯一的独用的数据槽（一块内存空间）

            //传递DbContext进去获取实例的信息，在这里进行强制转换。

            DbContext dbContext = CallContext.GetData("DbContext") as DbContext;

            if (dbContext == null)  //线程在数据槽里面没有此上下文

            {

                dbContext = new ShopSystemDBEntities1(); //如果不存在上下文的话，创建一个EF上下文

                //我们在创建一个，放到数据槽中去

                CallContext.SetData("DbContext", dbContext);

            }

            return dbContext;

        }
    }
}
