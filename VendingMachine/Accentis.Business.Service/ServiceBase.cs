using Accentis.Business.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accentis.Business.Service
{
    public abstract class ServiceBase : IDisposable
    {
        protected readonly IUnitOfWork unitOfWork;

        protected ServiceBase(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Dispose()
        {
            this.unitOfWork.Dispose();
        }
    }
}
