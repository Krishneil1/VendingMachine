using Accentic.Business.Interfaces;
using Accentis.Business.Dal.VenderMachineRespoitory;
using Accentis.Database.Domain.Models;
using System;

namespace Accentis.Business.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly ApplicationDbContext context;

        private bool disposed;
        public UnitOfWork(ApplicationDbContext context)
        {
            this.context = context;

            // DemoRepository = new DemoRepository(context);
            venderMachineRepository = new VenderMachineRepository(context);
        }



        // public IDemoRepository DemoRepository { get; }

        public IVenderMachineRepository venderMachineRepository { get; }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed && disposing)
            {
                context.Dispose();
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
