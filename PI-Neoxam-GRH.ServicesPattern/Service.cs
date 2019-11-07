using PI_Neoxam_GRH.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI_Neoxam_GRH.ServicesPattern
{
    public class Service<T> : IService<T> where T : class
    {

        //static IDatabaseFactory factory = new DatabaseFactory();
         IUnitOfWork unitOfWork;


        public Service(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public void Add(T entity)
        {
            unitOfWork.getRepository<T>().Add(entity);
        }

        public void Commit()
        {
            unitOfWork.Commit();
        }

        public void Delete(System.Linq.Expressions.Expression<Func<T, bool>> condition)
        {
            unitOfWork.getRepository<T>().Delete(condition);


        }

        public void Delete(T entity)
        {
            unitOfWork.getRepository<T>().Delete(entity);
        }

        public void Dispose()
        {
           unitOfWork.Dispose();
        }

        public T Get(System.Linq.Expressions.Expression<Func<T, bool>> condition)
        {
            return unitOfWork.getRepository<T>().Get(condition);
        }

        public T GetById(string Id)
        {
            return unitOfWork.getRepository<T>().GetById(Id);
        }

        public T GetById(int Id)
        {
            return unitOfWork.getRepository<T>().GetById(Id);
        }

        public IEnumerable<T> GetMany(System.Linq.Expressions.Expression<Func<T, bool>> condition = null, System.Linq.Expressions.Expression<Func<T, bool>> orderBy = null)
        {
            return unitOfWork.getRepository<T>().GetMany(condition,orderBy);
        }

        public void Update(T entity)
        {
            unitOfWork.getRepository<T>().Update(entity);
        }


        public virtual IEnumerable<T> GetAll()
        {
            return unitOfWork.getRepository<T>().GetAll();
  
        }
        public virtual int getcount()
        {
            return unitOfWork.getRepository<T>().GetMany().Count();

        }



    }
}
