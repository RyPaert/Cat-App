using System;
using System.Linq;
using Catblog.Controllers;
using Catblog.Data;
using Catblog.ServiceInterface;
using Catblog.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TestProject.Macros;
using TestProject.Mock;

namespace TestProject
{
    public abstract class TestBase
    {
        protected IServiceProvider serviceProvider { get; set; }

        protected TestBase()
        {
            var services = new ServiceCollection();
            SetupServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        public virtual void SetupServices(IServiceCollection services)
        {
            services.AddScoped<IPostServices, PostServices>();
            services.AddScoped<IFileServices, FileServices>();
            services.AddScoped<PostController, PostController>();
            services.AddSingleton<IHostEnvironment, MockIHostEnvironment>();
            services.AddSingleton<IWebHostEnvironment>(sp =>
                (IWebHostEnvironment)sp.GetRequiredService<IHostEnvironment>());

            services.AddDbContext<CatblogDb>(x =>
            {
                x.UseInMemoryDatabase("TEST");
                x.ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning));
            });

            RegisterMacros(services);
        }

        public void Dispose() { }

        protected T Svc<T>()
        {
            return serviceProvider.GetService<T>();
        }

        private void RegisterMacros(IServiceCollection services)
        {
            var macroBaseType = typeof(IMacros);
            var macros = macroBaseType.Assembly.GetTypes().Where(t =>
                macroBaseType.IsAssignableFrom(t) &&
                !t.IsInterface &&
                !t.IsAbstract);

            foreach (var macro in macros)
            {
                services.AddSingleton(macro);
            }
        }
    }
}
