using Accentis.Database.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accentic.Business.Interfaces.Services
{
    public interface IVenderMachineService
    {
        VenderMachine GetById(Guid productId);
        IQueryable<VenderMachine> GetAll();
        VenderMachine EditAddProduct(VenderMachine venderMachine);        
    }
}
