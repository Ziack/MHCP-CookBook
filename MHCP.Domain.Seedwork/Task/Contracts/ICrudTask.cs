using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MHCP.Domain.Seedwork.Task.Contracts
{
    public interface ICrudTask<TId, T> : IGetAllTask<T>, IGetTask<TId, T>, ICreateOrUpdateTask<T>, IDeleteTask
    {
    }
}
