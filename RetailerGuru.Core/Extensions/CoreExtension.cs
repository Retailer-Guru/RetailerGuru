using MediatR;
using MediatR.SimpleInjector;
using Microsoft.EntityFrameworkCore;
using RetailerGuru.Core.Services;
using RetailerGuru.Data;
using SimpleInjector;

namespace RetailerGuru.Core.Extensions
{
    public static class CoreExtension
    {
        public static Container AddCore(this Container container, Action<CoreConfigurationBuilder> options)
        {
            var config = new CoreConfigurationBuilder();
            options(config);

            container.RegisterDecorator(typeof(IRequestHandler<,>), typeof(Decorators.ValidationRequestHandlerDecorator<,>));

            var currentAssembly = typeof(CoreExtension).Assembly;
            container.BuildMediator(currentAssembly);

            RegisterContext(container, config);

            container.Register<AuthService>(Lifestyle.Singleton);

            return container;
        }

        public static void RegisterContext(this Container container, CoreConfigurationBuilder config)
        {
            var builder = new DbContextOptionsBuilder();

            if (config.UseInMemoryDBContext)
            {
                builder.UseInMemoryDatabase(nameof(RetailerGuruContext));
                builder.ConfigureWarnings(w => w.Ignore(Microsoft.EntityFrameworkCore.Diagnostics.InMemoryEventId.TransactionIgnoredWarning));
            }
            else if (!string.IsNullOrEmpty(config.ConnectionString))
            {
                // TODO: Durch live Db erstetzen
                // builder.UseMySql(config.ConnectionString, ServerVersion.AutoDetect(config.ConnectionString));
                throw new InvalidOperationException("Live Db Connection not implemented jet!!!");
            }
            else
            {
                throw new NotImplementedException("Cannot configure for sql server because options.ConnectionString is null or empty");
            }

            container.RegisterInstance(builder.Options);
            container.Register<RetailerGuruContext>(Lifestyle.Scoped);
        }
    }
}
