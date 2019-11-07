using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PI_Neoxam_GRH.ServicesPattern
{
    public interface IService<T> where T : class
    {
        void Add(T entity);
        void Delete(T entity);
        //supprimer selon une condition passé en paramétre
        void Delete(Expression<Func<T, bool>> condition);
        void Update(T entity);
        T Get(Expression<Func<T, bool>> condition);
        T GetById(int Id);
        T GetById(string Id);
        //GetMany() or GetMany(with param(s))
        IEnumerable<T> GetMany(Expression<Func<T, bool>> condition = null, Expression<Func<T, bool>> orderBy = null);
        IEnumerable<T> GetAll();

        void Commit();
        void Dispose();
       int getcount();

    }
}
