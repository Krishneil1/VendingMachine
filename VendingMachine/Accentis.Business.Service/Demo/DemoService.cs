using Accentic.Business.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accentis.Business.UoW;
using model = Accentis.Database.Domain.Models;

namespace Accentis.Business.Service.Demo
{
    public class DemoService : ServiceBase, IDemoService
    {
        public DemoService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }


        public model.Demo GetById(int id)
        {
            return unitOfWork.DemoRepository.Get(id);
        }
    }
}
