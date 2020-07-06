using ServiceStack.OrmLite;
using System.Web.Mvc;
using api;
using ServiceStack.MiniProfiler;
using ServiceStack.MiniProfiler.Data;
using ServiceStack.OrmLite.MySql;
using System.Configuration;
using api.Interfaces;
using api.Repositories;
using api.Repositories.ORMLight;
using api.Services;
using ServiceStack.Text;
using ServiceStack.Mvc;

namespace RestWbApi
{
    public class AppConfig
    {
        public static void DefaultConfig(Funq.Container container)
        {
            var provider = MySqlDialectProvider.Instance;

            container.Register<IDbConnectionFactory>(
                new OrmLiteConnectionFactory(
                    ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString, provider)
                {
                    ConnectionFilter = x => new ProfiledDbConnection(x, Profiler.Current)
                });

            container.Register<IUnitOfWorkProvider>(new UnitOfWorkProvider(container.Resolve<IDbConnectionFactory>()));
            container.Register<IConfig>(new ApiConfig(container.Resolve<IDbConnectionFactory>()));

            container.Register<IUserRepo>(new UserRepository(container.Resolve<IUnitOfWorkProvider>()));

            container.Register<IEditModelHerper>(new EditModelHelper(container.Resolve<IUserRepo>()));
            container.Register<IUserService>(new UserService(container.Resolve<IUserRepo>(),
                container.Resolve<IEditModelHerper>()));

            


            ControllerBuilder.Current.SetControllerFactory(new FunqControllerFactory(container));

        }


        public static void Initialize(Funq.Container container)
        {
            DefaultConfig(container);

            JsConfig.EmitCamelCaseNames = true;
            JsConfig.DateHandler = ServiceStack.Text.JsonDateHandler.ISO8601;

            var config = container.Resolve<IConfig>();
            config.Configure();

            
        }
    }
}