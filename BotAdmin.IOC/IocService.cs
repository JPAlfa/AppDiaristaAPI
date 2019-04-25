using Autofac;
using Microsoft.Extensions.Configuration;
using AppDiarista.Common.Interfaces;
using AppDiarista.Common.Notification;
using AppDiarista.ServiceApplication;
using AppDiarista.ServiceApplication.Interfaces;
using AppDiarista.ControleAcesso.Factory;
using AppDiarista.ControleAcesso.Interfaces.Factory;
using AppDiarista.ControleAcesso.Providers;
using AppDiarista.ControleAcesso.Interfaces.Providers;
using AppDiarista.Business;
using AppDiarista.Business.Interfaces;
using AppDiarista.Data.UnitOfWork;
using AppDiarista.Data.UnitOfWork.Interfaces;
using AppDiarista.Data;
using AppDiarista.Data.Interfaces;

namespace AppDiarista.IOC
{
    public class IocService : Module
    {
        private readonly IConfiguration Configuration;

        public IocService(IConfiguration configuration) 
        {
            Configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            //Commom
            RegistrarCommom(builder);

            // Service application
            RegistrarServiceApplication(builder);

            // Proxy
            RegistrarProxy(builder);

            // Controle de Acesso
            RegistrarControleAcesso(builder);

            //WCF
            RegistrarWCF(builder);

            // Factory
            RegistrarFactory(builder);

            // Business
            RegistrarBusiness(builder);

            //Data
            RegistrarData(builder);
        }

        private static void RegistrarServiceApplication(ContainerBuilder builder)
        {
            builder.RegisterType<IntencaoService>().As<IIntencaoService>().InstancePerLifetimeScope();
        }

        private static void RegistrarFactory(ContainerBuilder builder)
        {
        }

        private static void RegistrarBusiness(ContainerBuilder builder)
        {
            builder.RegisterType<IntencaoBusiness>().As<IIntencaoBusiness>().InstancePerLifetimeScope();
        }

        private static void RegistrarData(ContainerBuilder builder)
        {
            builder.RegisterType<UOWAppDiarista>().As<IUOWAppDiarista>().InstancePerLifetimeScope();
            builder.RegisterType<IntencaoData>().As<IIntencaoData>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(RepositorioBase<,>)).As(typeof(IRepositorioBase<,>)).InstancePerLifetimeScope();
        }

        private static void RegistrarCommom(ContainerBuilder builder)
        {
            builder.RegisterType<Notificacao>().As<INotificacao>().InstancePerLifetimeScope();
            builder.RegisterType<Notificador>().As<INotificador>().InstancePerLifetimeScope();
        }

        private static void RegistrarProxy(ContainerBuilder builder)
        {
            //builder.RegisterType<ApplicationProxy>().As<IApplicationProxy>().InstancePerLifetimeScope();
        }

        // todo verificar se precisa ser estático e verificar solução para obter configuracoes
        private void RegistrarWCF(ContainerBuilder builder)
        {
            
        }

        private static void RegistrarControleAcesso(ContainerBuilder builder)
        {
            builder.RegisterType<UsuarioFactory>().As<IUsuarioFactory>().InstancePerLifetimeScope();
        }
    }
}
