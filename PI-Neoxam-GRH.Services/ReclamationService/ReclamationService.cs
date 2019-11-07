using PI_Neoxam_GRH.Data.Infrastructure;
using PI_Neoxam_GRH.Domain.Enities;
using PI_Neoxam_GRH.ServicesPattern;

namespace PI_Neoxam_GRH.Services.ReclamationService
{
    public class ReclamationService : Service<reclamation>, IReclamationService
    {    //connection
        private static IDatabaseFactory dbFactory = new DatabaseFactory();
        //crud
        private static UnitOfWork uow = new UnitOfWork(dbFactory);

        public ReclamationService(): base(uow)
        {

        }

     

        public void addrec(reclamation r)
        {
            uow.getRepository<reclamation>().Add(r);
            uow.Commit();
        }
    }
}
