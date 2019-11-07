using PI_Neoxam_GRH.Data.Infrastructure;
using PI_Neoxam_GRH.Domain.Enities;
using PI_Neoxam_GRH.ServicesPattern;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI_Neoxam_GRH.Services.TopicService
{
   public class TopicService : Service<topic>, ITopicService
    {
        //connection
        private static IDatabaseFactory dbFactory = new DatabaseFactory();
        //crud
        private static UnitOfWork uow = new UnitOfWork(dbFactory);

        public TopicService(): base(uow)
        {

        }

    }
}
