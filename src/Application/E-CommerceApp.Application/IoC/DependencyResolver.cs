using Autofac;
using AutoMapper;
using E_CommerceApp.Application.AutoMapper;
using E_CommerceApp.Application.Services.AdminService;
using E_CommerceApp.Application.Services.LoginService;
using E_CommerceApp.Domain.Repositories;
using E_CommerceApp.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceApp.Application.IoC
{
    public class DependencyResolver : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EmployeeRepo>().As<IEmployeeRepo>().InstancePerLifetimeScope();
            builder.RegisterType<AdminService>().As<IAdminService>().InstancePerLifetimeScope();
            builder.RegisterType<ManagerService>().As<IManagerService>().InstancePerLifetimeScope();
            builder.RegisterType<LoginService>().As<ILoginService>().InstancePerLifetimeScope();
            builder.Register(context => new MapperConfiguration(cfg =>
            {                
                cfg.AddProfile<Mapping>();
            }
                        )).AsSelf().SingleInstance();

            builder.Register(c =>
            {                
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
