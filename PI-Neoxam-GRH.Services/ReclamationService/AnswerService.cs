using PI_Neoxam_GRH.Data.Infrastructure;
using PI_Neoxam_GRH.Domain.Enities;
using PI_Neoxam_GRH.ServicesPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Linq.Expressions;

namespace PI_Neoxam_GRH.Services.ResultService
{
    public class AnswerService : Service<answer>, IAnswerService
    {    //connection
        
        private static IDatabaseFactory dbFactory = new DatabaseFactory();
        //crud
        private static UnitOfWork uow = new UnitOfWork(dbFactory);

        public AnswerService(): base(uow)
        {

        }



        public void addrec(result r)
        {
            uow.getRepository<result>().Add(r);
            uow.Commit();
        }
    }
}
