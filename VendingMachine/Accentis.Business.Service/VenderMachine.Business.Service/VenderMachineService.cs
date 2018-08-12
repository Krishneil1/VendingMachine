using Accentic.Business.Interfaces.Services;
using Accentis.Business.UoW;
using Accentis.Database.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accentis.Business.Service.VenderMachine.Business.Service
{
    public class VenderMachineService : ServiceBase, IVenderMachineService
    {
        public VenderMachineService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public Database.Domain.Models.VenderMachine GetById(Guid productId)
        {
            return unitOfWork.venderMachineRepository.Get(productId);
        }

        public IQueryable<Database.Domain.Models.VenderMachine> GetAll()
        {
            return unitOfWork.venderMachineRepository.GetAll();
        }

        public Database.Domain.Models.VenderMachine EditAddProduct(Database.Domain.Models.VenderMachine venderMachine)
        {
            if (venderMachine.ProductId.ToString() != Guid.Empty.ToString())
            {
                unitOfWork.venderMachineRepository.Update(venderMachine);
                unitOfWork.venderMachineRepository.Save();
                return venderMachine;
            }
            else
            {
                venderMachine.ProductId = Guid.NewGuid();
                var data = unitOfWork.venderMachineRepository.Insert(venderMachine);
                unitOfWork.venderMachineRepository.Save();
                return data;
            }
        }
    }
}
