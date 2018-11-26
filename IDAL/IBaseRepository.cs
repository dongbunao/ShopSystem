using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface IBaseRepository<T> where T : class, new()

    {

        // Implement the function of adding database, add the reference of implementing EF framework

        T AddEntity(T entity);


        //Implementing the function of database modification
        

        bool UpdateEntity(T entity);



        //Implementing deletion function of database
        bool DeleteEntity(T entity);



        //Implementing the Query of Database--Simple Query

        IQueryable<T> LoadEntities(Func<T, bool> whereLambda);



        /// <summary>

        /// Implementing Paging Query of Data

        /// </summary>

       

        IQueryable<T> LoadPageEntities<S>(int pageIndex, int pageSize, out int total, Func<T, bool> whereLambda, bool isAsc, Func<T, S> orderByLambda);

    }
}
