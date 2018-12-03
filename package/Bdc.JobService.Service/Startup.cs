using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Bdc.JobService.Businesslogic.FooStaff;
using Bdc.JobService.Service.Configuration;
using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Bdc.JobService.Service
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", b => b.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.AddHangfire(config =>
            {
                config.UseMemoryStorage();
            });


            var builder = new ContainerBuilder();
            builder.Populate(services);

            var connectionString = Configuration.GetValue<string>("connectionString");
            builder.RegisterModule(new ServiceModule(connectionString));

            var container = builder.Build();
            var serviceProvider = new AutofacServiceProvider(container);

            GlobalConfiguration.Configuration.UseAutofacActivator(container);

            return serviceProvider;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHangfireDashboard();
            app.UseHangfireServer();

            app.UseCors("CorsPolicy");
            app.UseMvc();

            ConfigureHangfireTasks();
        }

        private void ConfigureHangfireTasks()
        {
            var fooCron = Configuration.GetValue<string>("tasks:cron:foo");
            RecurringJob.AddOrUpdate<IFooWork>(HangfireTaskKeys.Foo, foo => foo.DoWork(), fooCron);
        }
    }
}
