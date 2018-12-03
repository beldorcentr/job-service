using Autofac;
using Bdc.JobService.DataAccess.FooStaff;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Bdc.JobService.DataAccess.Configuration
{
    public class DataAccessModule : Module
    {
        private readonly string _connectionString;

        public DataAccessModule(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            //// MS SQL Connection
            //builder.Register(c => new SqlConnection(_connectionString))
            //    .As<IDbConnection>()
            //    .InstancePerLifetimeScope();

            //// Oracle connection
            //builder.Register(c => new OracleConnection(_connectionString))
            //    .As<IDbConnection>()
            //    .InstancePerLifetimeScope();

            builder.RegisterType<FooStorage>()
                .As<IFooStorage>()
                .InstancePerLifetimeScope();
        }
    }
}
