using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Bdc.JobService.DataAccess.FooStaff
{
    internal class FooStorage : IFooStorage
    {
        private readonly IDbConnection _dbConnection;

        public FooStorage() { }

        public FooStorage(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public Foo GetFoo(int id)
        {
            return new Foo()
            {
                Id = id,
                Count = 42
            };


            //Dapper query:
            //Argument format: :bar - Oracle, @bar - MsSql
            //return _dbConnection.Query<Foo>("SELECT ID, COUNT FROM FOO WHERE BAR = :bar",
            //        new { bar = "Bar" })
            //    .ToList();
        }
    }
}
