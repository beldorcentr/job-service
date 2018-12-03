using Autofac;
using Bdc.JobService.Businesslogic.FooStaff;
using Bdc.JobService.DataAccess.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bdc.JobService.Businesslogic.Configuration
{
    public class BusinessLogicModule : Module
    {
        private readonly string _connectionString;

        public BusinessLogicModule(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FooWork>()
                .As<IFooWork>()
                .InstancePerLifetimeScope();

            builder.RegisterModule(new DataAccessModule(_connectionString));
        }
    }
}
