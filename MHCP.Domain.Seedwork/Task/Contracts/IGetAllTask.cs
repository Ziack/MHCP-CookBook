using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MHCP.Domain.Seedwork.Task.Contracts
{
    public interface IGetAllTask<T>
    {
        List<T> GetAll();
    }
}
