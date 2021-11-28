using NLayerProject.Core.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerProject.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        IProductRepository Product { get; }
        ICategoryRepository Category { get; }
        Task CommitAsync();
        void Commit();

    }
}
