using Accentic.Business.Interfaces;
using Accentis.Business.Dal.General;
using Accentis.Database.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accentis.Business.Dal.VenderMachineRespoitory
{
    public class VenderMachineRepository : BaseRepository<VenderMachine>, IVenderMachineRepository
    {
        public VenderMachineRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
