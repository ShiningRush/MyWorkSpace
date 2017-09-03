using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MyWorkSpace.Domain.INeeds.DataAccess
{
    public interface IDatabaseMediator
    {
        IQueryable<T> GetAll<T>() where T : class;
    }
}
