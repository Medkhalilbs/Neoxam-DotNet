using PI_Neoxam_GRH.Domain.Enities;
using PI_Neoxam_GRH.ServicesPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PI_Neoxam_GRH.Data.Infrastructure;

namespace PI_Neoxam_GRH.Services.SkillsServices
{
    public class SkillsService : Service<skill>, ISkillsService
    {

        private static IDatabaseFactory dbFactory = new DatabaseFactory();
        private static IUnitOfWork uow = new UnitOfWork(dbFactory);

        public SkillsService() : base(uow)
        {
        }
    }
}
