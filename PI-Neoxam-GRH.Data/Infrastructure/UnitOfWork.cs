using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI_Neoxam_GRH.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private Context dataContext;

        IDatabaseFactory dbFactory;
        public UnitOfWork(IDatabaseFactory dbFactory)
        {
            this.dbFactory = dbFactory;
            dataContext = dbFactory.DataContext;
        }
        public void Commit()
        {
            dataContext.SaveChanges();
        }

        public void Dispose()
        {
            dataContext.Dispose();
        }
        public RepositoryBase<T> getRepository<T>() where T : class
        {
            RepositoryBase<T> repo = new RepositoryBase<T>(dbFactory);
            return repo;
        }
     

    }
}
