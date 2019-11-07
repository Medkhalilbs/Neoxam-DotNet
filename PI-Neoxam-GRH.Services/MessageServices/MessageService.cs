using PI_Neoxam_GRH.Data.Infrastructure;
using PI_Neoxam_GRH.Domain.Enities;
using PI_Neoxam_GRH.ServicesPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI_Neoxam_GRH.Services.UserServices
{
    public class MessageService : Service<message>, IMessageService
    {
        private static IDatabaseFactory dbFactory = new DatabaseFactory();
        private static IUnitOfWork uow = new UnitOfWork(dbFactory);
        public MessageService(): base (uow)
        {
                        
        }

    }
}
