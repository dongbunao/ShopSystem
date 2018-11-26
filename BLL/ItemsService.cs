using IBLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ItemsService : BaseService<tb_Items>,IItemsService
    {
        public override void SetCurrentRepository()
        {
            CurrentRepository = DAL.RepositoryFactory.DALItems;

        }
    }
}
