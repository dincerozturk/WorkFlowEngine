using Autofac;
using Autofac.Core;
using AutoMapper;
using Hangfire;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
//using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Data.Entity;
using System.Text.Json.Serialization;
using WorkflowManager.Common.Dto;
using WorkFlowManager.Common.Constants;
using WorkFlowManager.Common.DataAccess._Context;
using WorkFlowManager.Common.DataAccess._UnitOfWork;
using WorkFlowManager.Common.DataAccess.Repositories;
using WorkFlowManager.Common.Factory;
using WorkFlowManager.Helper;
using WorkFlowManager.Services.CustomForms;
using WorkFlowManager.Services.DbServices;
using WorkFlowManager.Web;
namespace WFE.Core.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            ).AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddHttpClient();
            builder.Services.AddHttpContextAccessor();


            //var connectingstring = builder.Configuration.GetConnectionString("DefaultConnection");

            //string migrationassembly = "WorkFlowManager.Common.DataAccess._Context";
            //builder.Services.AddDbContext<DbContext>(options =>
            //{
            //    //options = optionBuilder;
            //    options.UseSqlServer(connectingstring, b => b.MigrationsAssembly(migrationassembly));
            //    options.EnableDetailedErrors();
            //    options.EnableSensitiveDataLogging();
            //    //options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            //}, ServiceLifetime.Scoped
            //);
            //builder.Services.AddScoped<DbContext, DataContext>();
            //services.AddDbContext<WorkFlowManager.Web.Models.ApplicationDbContext>(options => options.UseSqlServer(Configuration["ConnectionString"]));

            builder.Services.AddDependencies();
            builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            builder.Services.AddHttpContextAccessor();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapBlazorHub();
            app.Run();
        }
    }

    public static class Dependencies
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<DbContext, DataContext>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ITestWorkFlowForm, TestWorkFlowForm>();
            services.AddScoped<IHealthInformationWorkFlowForm, HealthInformationWorkFlowForm>();
            services.AddScoped<IDecisionMethodService, DecisionMethodService>();
            services.AddScoped<IDocumentService, DocumentService>();
            services.AddScoped<IFormService, FormService>();
            services.AddScoped<IWorkFlowDataService, WorkFlowDataService>();
            services.AddScoped<ITestWorkFlowProcessService, TestWorkFlowProcessService>();
            services.AddScoped<IWorkFlowProcessService, WorkFlowProcessService>();
            services.AddScoped<ITestWorkFlowForm, TestWorkFlowForm>();
            services.AddScoped<IWorkFlowService, WorkFlowService>();
            services.AddScoped<IGlobal, Global2>();
            services.AddScoped<IWorkFlowUtil, WorkFlowUtil>();
            services.AddScoped<IProcessFactory, ProcessFactory>();
            services.AddScoped<IValidationHelper, ValidationHelper>();

            #region automapper

            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //// use cfg to configure AutoMapper
            //var config = new MapperConfiguration(cfg => cfg.AddProfile<MapperProfile>());
            //var mapper = config.CreateMapper();
            //// or
            ////var mapper = new Mapper(config);
            //services.AddSingleton<IMapper>(mapper);

            //var mapperConfig = new MapperConfiguration(mc =>
            //{
            //    mc.AddProfile(new MapperProfile());
            //});
            //IMapper mapper = mapperConfig.CreateMapper();
            //services.AddSingleton(mapper);


            #endregion
        }
    }

}