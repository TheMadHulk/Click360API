using System;
using System.Data.SqlClient;
using System.Reflection;
using Autofac;
using Microsoft.Extensions.Configuration;
using NPoco;
using Click360.Core.Database;
using Click360.Core.Database.Interfaces;
using Module = Autofac.Module;

namespace Click360.Core
{
    public class CoreModule : Module
    {
        private readonly IConfiguration Configuration;

        public CoreModule(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            /**********************************************
             **
             **     PLEASE ENSURE THESE REMAIN ALPHABETICAL
             **
             **/

            // Setup DB Connection
            var Click360ConnectionString = Configuration.GetConnectionString("Click360Database");
                                                                                     
            builder.Register(c => new Click360Database(Click360ConnectionString, DatabaseType.SqlServer2012, SqlClientFactory.Instance))
                   .As<IClick360Database>()
                   .InstancePerLifetimeScope();

            // Register any repositories
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                   .Where(t => t.Name.EndsWith("Repository", StringComparison.OrdinalIgnoreCase))
                   .AsImplementedInterfaces();

            // Register any services
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                   .Where(t => t.Name.EndsWith("Service", StringComparison.OrdinalIgnoreCase))
                   .AsImplementedInterfaces();
        }
    }
}
