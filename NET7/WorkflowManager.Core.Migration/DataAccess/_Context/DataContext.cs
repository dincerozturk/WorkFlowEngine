//using Microsoft.AspNet.Identity.EntityFramework;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
//using System.Data.Entity;
//using System.Data.Entity.ModelConfiguration.Conventions;
//using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using WorkFlowManager.Common.DataAccess.Repositories;
using WorkFlowManager.Common.Mapping;
using WorkFlowManager.Common.Tables;

namespace WorkFlowManager.Common.DataAccess._Context
{
    public class DataContext : DbContext //IdentityDbContext
    {
        public DataContext(Microsoft.EntityFrameworkCore.DbContextOptions options) : base(options)
        {
            //options.UseSqlServer("Data Source =.; Initial Catalog = WorkFlowManagerDB; User Id=sa; Password=123456; MultipleActiveResultSets=True; Integrated Security = false");
        }

//        public DataContext() : base("WorkFlowManagerDB")
//        {
//            //Database.CommandTimeout = 180;
//            //Lazy loading
//            Configuration.LazyLoadingEnabled = false;
//#if DEBUG
//            Database.Log = message => Trace.WriteLine(message);
//#endif
//        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           

            modelBuilder.Entity<WorkFlowEngineVariable>().ToTable("WorkFlowEngineVariableTbl");

            modelBuilder.Entity<SubProcess>().ToTable("SubProcessTbl");

            modelBuilder.ApplyConfiguration<BaseTable>(new BaseTableTableMap());
            modelBuilder.ApplyConfiguration<Condition>(new ConditionMap());

            modelBuilder.ApplyConfiguration<Document>(new DocumentMap());

            modelBuilder.ApplyConfiguration<WorkFlowManager.Common.Tables.Task>(new TaskMap());
            modelBuilder.ApplyConfiguration<WorkFlowManager.Common.Tables.Process>(new ProcessMap());
            modelBuilder.ApplyConfiguration<ConditionOption>(new ConditionOptionMap());
            modelBuilder.ApplyConfiguration<ProcessMonitoringRole>(new ProcessMonitoringRoleMap());
            modelBuilder.ApplyConfiguration<WorkFlow>(new WorkFlowMap());

            modelBuilder.ApplyConfiguration<FormView>(new FormViewMap());
            modelBuilder.ApplyConfiguration<DecisionMethod>(new DecisionMethodMap());
            modelBuilder.ApplyConfiguration<DecisionPoint>(new DecisionPointMap());
            modelBuilder.ApplyConfiguration<WorkFlowTrace>(new WorkFlowTraceMap());
            modelBuilder.ApplyConfiguration<TestForm>(new TestFormMap());
            modelBuilder.ApplyConfiguration<BusinessProcess>(new BusinessProcessMap());

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.NoAction;
            }

            base.OnModelCreating(modelBuilder);

            //modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

        }


        //public override int SaveChanges()
        //{
        //    try
        //    {

        //        var models = ChangeTracker.Entries()
        //        .Where(x => x.Entity is ABaseTable
        //        && x.State == EntityState.Added || x.State == EntityState.Modified);

        //        foreach (var model in models)
        //        {
        //            ABaseTable table = model.Entity as ABaseTable;
        //            if (table != null)
        //            {

        //                DateTime now = DateTime.Now;

        //                if (model.State == EntityState.Added)
        //                {
        //                    table.CreatedTime = now;
        //                }
        //                else if (model.State == EntityState.Modified)
        //                {
        //                    base.Entry(table).Property(x => x.CreatedTime).IsModified = false;

        //                    table.UpdatedTime = now;
        //                }

        //            }
        //        }
        //        return base.SaveChanges();

        //    }
        //    catch (DbEntityValidationException ex)
        //    {
        //        var sb = new StringBuilder();
        //        foreach (var eve in ex.EntityValidationErrors)
        //        {
        //            string error =
        //                string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
        //                    eve.Entry.Entity.GetType().Name, eve.Entry.State);


        //            foreach (var ve in eve.ValidationErrors)
        //            {
        //                string local = string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);

        //                sb.Append(local.ToString());
        //            }
        //        }
        //        throw new DbEntityValidationException(sb.ToString(), ex.EntityValidationErrors);
        //    }
        //}


        //public new IDbSet<T> Set<T>() where T : class
        //{
        //    return base.Set<T>();
        //}

    }
}

