using Autofac;
using Autofac.Integration.WebApi;
using SchoolManagement.Application.Mappers;
using SchoolManagement.Application.Services;
using SchoolManagement.Domain.Interfaces.Services;
using SchoolManagement.Domain.Models;
using SchoolManagement.Infrastructure.Authentication;
using SchoolManagement.Infrastructure.Authentication.Interfaces;
using SchoolManagement.Infrastructure.Configurations;
using SchoolManagement.Infrastructure.Configurations.Interfaces;
using SchoolManagement.Infrastructure.Persistence;
using System.Web.Http;

namespace SchoolManagement.Web.App_Start
{
    public static class DependencyInjectionConfig
    {
        public static void Register()
        {

            var builder = new ContainerBuilder();

            builder.RegisterType<ApplicationDbContext>().AsSelf().InstancePerLifetimeScope();

            builder.RegisterType<JwtOptions>().As<IJwtOptions>().SingleInstance();
            builder.RegisterType<JwtTokenService>().As<ITokenService>().InstancePerRequest();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();

            builder.RegisterType<UserMapper>().InstancePerLifetimeScope();
            builder.RegisterType<RoleMapper>().InstancePerLifetimeScope();
            builder.RegisterType<CourseMapper>().InstancePerLifetimeScope();
            builder.RegisterType<CourseTeacherMapper>().InstancePerLifetimeScope();
            builder.RegisterType<CourseStudentMapper>().InstancePerLifetimeScope(); 

            builder.RegisterType<AuthenticationService>().As<IAuthenticationService>().InstancePerRequest();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerRequest();
            builder.RegisterType<RoleService>().As<IRoleService>().InstancePerRequest();
            builder.RegisterType<CourseService>().As<ICourseService>().InstancePerRequest();
            builder.RegisterType<CourseTeacherService>().As<ICourseTeacherService>().InstancePerRequest();
            builder.RegisterType<CourseStudentService>().As<ICourseStudentService>().InstancePerRequest();

            builder.RegisterApiControllers(typeof(WebApiApplication).Assembly);

            var container = builder.Build();
            var config = GlobalConfiguration.Configuration;
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}