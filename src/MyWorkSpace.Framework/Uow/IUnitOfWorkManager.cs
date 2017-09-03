using System;
using System.Collections.Generic;
using System.Text;

namespace MyWorkSpace.Framework.Uow
{
    public interface IUnitOfWorkManager
    {
        IUnitOfWork Current { get; set; }
    }
}
