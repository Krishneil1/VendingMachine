using Accentic.Business.Interfaces;
using Accentis.Database.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accentis.Business.UoW
{
    public interface IUnitOfWork : IDisposable    
    {
        //IDemoRepository DemoRepository { get; }
        IVenderMachineRepository venderMachineRepository { get; }
    }
}
