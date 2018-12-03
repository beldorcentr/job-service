using Bdc.JobService.DataAccess.FooStaff;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bdc.JobService.Businesslogic.FooStaff
{
    internal class FooWork : IFooWork
    {
        private IFooStorage _fooStorage;

        public FooWork(IFooStorage fooStorage)
        {
            _fooStorage = fooStorage;
        }

        public void DoWork()
        {
            var foo = _fooStorage.GetFoo(42);
        }
    }
}
