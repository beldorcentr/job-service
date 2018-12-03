using System;
using System.Collections.Generic;
using System.Text;

namespace Bdc.JobService.DataAccess.FooStaff
{
    public interface IFooStorage
    {
        Foo GetFoo(int id);
    }
}
