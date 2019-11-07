using PI_Neoxam_GRH.Data.Infrastructure;
using PI_Neoxam_GRH.Domain.Enities;
using PI_Neoxam_GRH.ServicesPattern;

namespace PI_Neoxam_GRH.Services.ResultService
{
    public class ResultService : Service<result>, IResultService
    {    //connection
        
        private static IDatabaseFactory dbFactory = new DatabaseFactory();
        //crud
        private static UnitOfWork uow = new UnitOfWork(dbFactory);

        public ResultService(): base(uow)
        {

        }



        public void addrec(result r)
        {
            uow.getRepository<result>().Add(r);
            uow.Commit();
        }
    }
}
