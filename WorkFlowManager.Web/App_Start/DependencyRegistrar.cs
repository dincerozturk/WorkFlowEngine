using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using Hangfire;
using Hangfire.Server;
using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using WorkflowManager.Common.Dto;
using WorkFlowManager.Common.Constants;
using WorkFlowManager.Common.DataAccess._Context;
using WorkFlowManager.Common.DataAccess._UnitOfWork;
using WorkFlowManager.Common.DataAccess.Repositories;
using WorkFlowManager.Common.Enums;
using WorkFlowManager.Common.Factory;
using WorkFlowManager.Common.Tables;
using WorkFlowManager.Common.ViewModels;
using WorkFlowManager.Helper;
using WorkFlowManager.Services.CustomForms;
using WorkFlowManager.Services.DbServices;

namespace WorkFlowManager.Web
{

    public class ContainerJobActivator : JobActivator
    {
        private IContainer _container;

        public ContainerJobActivator(IContainer container)
        {
            _container = container;
        }
        public override object ActivateJob(Type type)
        {
            return _container.Resolve(type);
        }
    }

    public class DependencyRegistrar
    {
        public static void RegisterDependencies()
        {


            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterModule(new AutofacWebTypesModule());

            builder.RegisterType<UnitOfWork>()
            .As<IUnitOfWork>()
            .InstancePerLifetimeScope();


            builder.RegisterType<DataContext>()
                .As<DbContext>()
                .InstancePerBackgroundJob()
                .InstancePerDependency();


            builder.RegisterType<TestWorkFlowForm>()
                .AsSelf()
                .InstancePerBackgroundJob()
                .InstancePerDependency();

            builder.RegisterType<HealthInformationWorkFlowForm>()
                .AsSelf()
                .InstancePerBackgroundJob()
                .InstancePerDependency();

            builder.RegisterGeneric(typeof(BaseRepository<>))
                .As(typeof(IRepository<>))
                .InstancePerDependency();



            builder.RegisterType<DecisionMethodService>()
                 .AsSelf()
                 .InstancePerLifetimeScope();

            builder.RegisterType<DocumentService>()
                .AsSelf()
                .InstancePerLifetimeScope();

            builder.RegisterType<FormService>()
                .AsSelf()
                .InstancePerLifetimeScope();



            builder.RegisterType<WorkFlowDataService>()
                .AsSelf()
                .InstancePerBackgroundJob()
                .InstancePerLifetimeScope();


            builder.RegisterType<TestWorkFlowProcessService>()
                .AsSelf()
                .InstancePerLifetimeScope();


            builder.RegisterType<WorkFlowProcessService>()
                .AsSelf()
                .InstancePerLifetimeScope();


            builder.RegisterType<WorkFlowService>()
                .AsSelf()
                .InstancePerLifetimeScope();

            #region MyRegion
            builder.RegisterType<TestWorkFlowForm>()
           .As<ITestWorkFlowForm>()
           .InstancePerLifetimeScope();

            builder.RegisterType<HealthInformationWorkFlowForm>()
          .As<IHealthInformationWorkFlowForm>()
          .InstancePerLifetimeScope();

            builder.RegisterType<DecisionMethodService>()
          .As<IDecisionMethodService>()
          .InstancePerLifetimeScope();

            builder.RegisterType<DocumentService>()
          .As<IDocumentService>()
          .InstancePerLifetimeScope();

            builder.RegisterType<FormService>()
          .As<IFormService>()
          .InstancePerLifetimeScope();

            builder.RegisterType<WorkFlowDataService>()
          .As<IWorkFlowDataService>()
          .InstancePerLifetimeScope();

            builder.RegisterType<TestWorkFlowProcessService>()
          .As<ITestWorkFlowProcessService>()
          .InstancePerLifetimeScope();

            builder.RegisterType<WorkFlowProcessService>()
          .As<IWorkFlowProcessService>()
          .InstancePerLifetimeScope();

            builder.RegisterType<WorkFlowService>()
         .As<IWorkFlowService>()
         .InstancePerLifetimeScope();

            builder.RegisterType<EmailService>()
         .As<IEmailService>()
         .InstancePerLifetimeScope();

            builder.RegisterType<SmsService>()
        .As<ISmsService>()
        .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationUserManager>()
        .As<IApplicationUserManager>()
        .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationSignInManager>()
        .As<IApplicationSignInManager>()
        .InstancePerLifetimeScope();

            builder.RegisterType<Global2>()
        .As<IGlobal>()
        .InstancePerLifetimeScope();

            builder.RegisterType<WorkFlowUtil>()
        .As<IWorkFlowUtil>()
        .InstancePerLifetimeScope();

            builder.RegisterType<ProcessFactory>()
        .As<IProcessFactory>()
        .InstancePerLifetimeScope();


            builder.RegisterType<ValidationHelper>()
       .As<IValidationHelper>()
       .InstancePerLifetimeScope();

            #region automapper
            // use cfg to configure AutoMapper
            var config = new MapperConfiguration(cfg => cfg.AddProfile<MapperProfile>());
            var mapper = config.CreateMapper();
            // or
            //var mapper = new Mapper(config);
            builder.RegisterInstance<IMapper>(mapper);
            #endregion

            #endregion

            var container = builder.Build();

            GlobalConfiguration.Configuration.UseActivator(new ContainerJobActivator(container));
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}