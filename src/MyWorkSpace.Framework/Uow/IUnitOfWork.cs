using System;
using System.Collections.Generic;
using System.Text;

namespace MyWorkSpace.Framework.Uow
{
    public interface IUnitOfWork
    {
        string Identity { get; set; }

        bool IsDispposed { get; set; }

        void Begin();

        void End();
    }
}
