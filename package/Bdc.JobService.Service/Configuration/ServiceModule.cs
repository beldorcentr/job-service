using Autofac;
using Bdc.JobService.Businesslogic.Configuration;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bdc.JobService.Service.Configuration
{
    public class ServiceModule : Module
    {
        private readonly string _connectionString;

        public ServiceModule(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<FooWork>()
            //    .As<IFooWork>()
            //    .InstancePerLifetimeScope();

            builder.Register(c => LogManager.GetCurrentClassLogger()).As<ILogger>();

            builder.RegisterModule(new BusinessLogicModule(_connectionString));
        }
    }
}
