using CTMMIS.DAL;
using CTMMIS.IBLL;
using CTMMIS.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CTMMIS.BLL
{
    public abstract partial class BaseService<T> : IBaseService<T> where T : class, new()
    {
        public IBaseDAL<T> Dal = new BaseDAL<T>();

        public void Dispose()
        {
            this.Dal.Dispose();
        }

        public bool Add(T t)
        {
            return Dal.Add(t);
        }
        public bool Delete(T t)
        {
            return Dal.Delete(t);
        }
        public bool Update(T t)
        {
            return Dal.Update(t);
        }
        public IQueryable<T> GetModels(Expression<Func<T, bool>> whereLambda)
        {
            return Dal.GetModels(whereLambda);
        }

        public IQueryable<T> GetModelsByPage<type>(int pageSize, int pageIndex, bool isAsc,
            Expression<Func<T, type>> OrderByLambda, Expression<Func<T, bool>> WhereLambda)
        {
            return Dal.GetModelsByPage(pageSize, pageIndex, isAsc, OrderByLambda, WhereLambda);
        }
    }
}
