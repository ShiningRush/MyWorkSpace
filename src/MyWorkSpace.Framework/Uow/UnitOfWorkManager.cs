using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MyWorkSpace.Framework.Uow
{
    public class UnitOfWorkManager : IUnitOfWorkManager
    {
        public static readonly AsyncLocal<IUnitOfWork> _current = new AsyncLocal<IUnitOfWork>();

        public UnitOfWorkManager(IUnitOfWork uow)
        {

        }

        public IUnitOfWork Current {
            get 
            {
                return _current.Value;
            }
            set => _current.Value = value; }
    }
}
