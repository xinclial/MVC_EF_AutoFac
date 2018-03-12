using CTMMIS.IDAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CTMMIS.DAL
{
    public class BaseDAL<T> : IBaseDAL<T> where T : class, new()
    {

        private DbContext dbContext = DbContextFactory.Create();

        public void Dispose()
        {
            this.dbContext.Dispose();
        }

        public bool Add(T t)
        {
            //using (DbContext dbContext = DbContextFactory.Create())
            //{
            //    dbContext.Set<T>().Add(t);
            //    return dbContext.SaveChanges() > 0;
            //}
            dbContext.Set<T>().Add(t);
            return dbContext.SaveChanges() > 0;
        }
        public bool Delete(T t)
        {
            //using (DbContext dbContext = DbContextFactory.Create())
            //{
            //    dbContext.Set<T>().Remove(t);
            //    return dbContext.SaveChanges() > 0;
            //}
            int yy = 90;
            dbContext.Set<T>().Remove(t);
            return dbContext.SaveChanges() > 0;

        }

        public bool Update(T t)
        {
            //using (DbContext dbContext = DbContextFactory.Create())
            //{
            //    dbContext.Set<T>().AddOrUpdate(t);
            //    return dbContext.SaveChanges() > 0;
            //}
            dbContext.Set<T>().AddOrUpdate(t);
            return dbContext.SaveChanges() > 0;
        }

        public IQueryable<T> GetModels(Expression<Func<T, bool>> whereLambda)
        {
            //using (DbContext dbContext = DbContextFactory.Create())
            //{
            //    return dbContext.Set<T>().Where(whereLambda).ToList();
            //}

            return dbContext.Set<T>().Where(whereLambda);

        }

        public IQueryable<T> GetModelsByPage<type>(int pageSize, int pageIndex, bool isAsc,
            Expression<Func<T, type>> OrderByLambda, Expression<Func<T, bool>> WhereLambda)
        {
            //using (DbContext dbContext = DbContextFactory.Create())
            //{
            //    //是否升序
            //    if (isAsc)
            //    {
            //        return dbContext.Set<T>().Where(WhereLambda).OrderBy(OrderByLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            //    }
            //    else
            //    {
            //        return dbContext.Set<T>().Where(WhereLambda).OrderByDescending(OrderByLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            //    }
            //}
            if (isAsc)
            {
                return dbContext.Set<T>().Where(WhereLambda).OrderBy(OrderByLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            else
            {
                return dbContext.Set<T>().Where(WhereLambda).OrderByDescending(OrderByLambda).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
        }

    }
}
