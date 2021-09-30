using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.DAL.UOW
{
    public interface IUnitOfWork:IDisposable
    {
        CompanyRepository CompanyRepository { get; }

        Task<int> Save();
    }
}
