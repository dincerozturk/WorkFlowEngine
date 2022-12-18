using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WFE.Core.Migration.EFCore.Models;

namespace WFE.Core.Migration.EFCore.Models;

public partial class WorkFlowManagerDbContext : DbContext
{
    public WorkFlowManagerDbContext()
    {
    }

    public WorkFlowManagerDbContext(DbContextOptions<WorkFlowManagerDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AggregatedCounter> AggregatedCounters { get; set; }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<BaseTable> BaseTables { get; set; }

    public virtual DbSet<BusinessProcess> BusinessProcesss { get; set; }

    public virtual DbSet<ConditionOption> ConditionOptions { get; set; }

    public virtual DbSet<Condition> Conditions { get; set; }

    public virtual DbSet<Counter> Counters { get; set; }

    public virtual DbSet<DecisionMethod> DecisionMethods { get; set; }

    public virtual DbSet<DecisionPoint> DecisionPoints { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<FormView> FormViews { get; set; }

    public virtual DbSet<Hash> Hashes { get; set; }

    public virtual DbSet<Job> Jobs { get; set; }

    public virtual DbSet<JobParameter> JobParameters { get; set; }

    public virtual DbSet<JobQueue> JobQueues { get; set; }

    public virtual DbSet<List> Lists { get; set; }

    public virtual DbSet<MigrationHistory> MigrationHistories { get; set; }

    public virtual DbSet<ProcessMonitoringRole> ProcessMonitoringRoles { get; set; }

    public virtual DbSet<Process> Processs { get; set; }

    public virtual DbSet<Schema> Schemas { get; set; }

    public virtual DbSet<Server> Servers { get; set; }

    public virtual DbSet<Set> Sets { get; set; }

    public virtual DbSet<State> States { get; set; }

    public virtual DbSet<SubProcess> SubProcesss { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    public virtual DbSet<TestForm> TestForms { get; set; }

    public virtual DbSet<WorkFlowEngineVariable> WorkFlowEngineVariables { get; set; }

    public virtual DbSet<WorkFlow> WorkFlows { get; set; }

    public virtual DbSet<WorkFlowTrace> WorkFlowTraces { get; set; }

    public virtual DbSet<WorkflowApprovalHistory> WorkflowApprovalHistories { get; set; }

    public virtual DbSet<WorkflowGlobalParameter> WorkflowGlobalParameters { get; set; }

    public virtual DbSet<WorkflowInbox> WorkflowInboxes { get; set; }

    public virtual DbSet<WorkflowProcessAssignment> WorkflowProcessAssignments { get; set; }

    public virtual DbSet<WorkflowProcessInstance> WorkflowProcessInstances { get; set; }

    public virtual DbSet<WorkflowProcessInstancePersistence> WorkflowProcessInstancePersistences { get; set; }

    public virtual DbSet<WorkflowProcessInstanceStatus> WorkflowProcessInstanceStatuses { get; set; }

    public virtual DbSet<WorkflowProcessScheme> WorkflowProcessSchemes { get; set; }

    public virtual DbSet<WorkflowProcessTimer> WorkflowProcessTimers { get; set; }

    public virtual DbSet<WorkflowProcessTransitionHistory> WorkflowProcessTransitionHistories { get; set; }

    public virtual DbSet<WorkflowRuntime> WorkflowRuntimes { get; set; }

    public virtual DbSet<WorkflowScheme> WorkflowSchemes { get; set; }

    public virtual DbSet<WorkflowSync> WorkflowSyncs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source =.; Initial Catalog = WorkFlowManagerDB; User Id=sa; Password=123456; MultipleActiveResultSets=True;  TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AggregatedCounter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_HangFire_CounterAggregated");

            entity.ToTable("AggregatedCounter", "HangFire");

            entity.HasIndex(e => e.Key, "UX_HangFire_CounterAggregated_Key").IsUnique();

            entity.Property(e => e.ExpireAt).HasColumnType("datetime");
            entity.Property(e => e.Key)
                .IsRequired()
                .HasMaxLength(100);
        });

        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.AspNetRoles");

            entity.HasIndex(e => e.Name, "RoleNameIndex").IsUnique();

            entity.Property(e => e.Id).HasMaxLength(128);
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.AspNetUsers");

            entity.HasIndex(e => e.UserName, "UserNameIndex").IsUnique();

            entity.Property(e => e.Id).HasMaxLength(128);
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");
            entity.Property(e => e.UserName)
                .IsRequired()
                .HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany()
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId").HasName("PK_dbo.AspNetUserRoles");
                        j.HasIndex(new[] { "RoleId" }, "IX_RoleId");
                        j.HasIndex(new[] { "UserId" }, "IX_UserId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.AspNetUserClaims");

            entity.HasIndex(e => e.UserId, "IX_UserId");

            entity.Property(e => e.UserId)
                .IsRequired()
                .HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId");
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId }).HasName("PK_dbo.AspNetUserLogins");

            entity.HasIndex(e => e.UserId, "IX_UserId");

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.ProviderKey).HasMaxLength(128);
            entity.Property(e => e.UserId).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId");
        });

        modelBuilder.Entity<BaseTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.BaseTable");

            entity.ToTable("BaseTable");

            entity.Property(e => e.CreatedTime).HasColumnType("datetime");
            entity.Property(e => e.UpdatedTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<BusinessProcess>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.BusinessProcess");

            entity.ToTable("BusinessProcess");

            entity.HasIndex(e => e.Id, "IX_Id");

            entity.HasIndex(e => e.OwnerId, "IX_OwnerId");

            entity.HasIndex(e => e.OwnerSubProcessTraceId, "IX_OwnerSubProcessTraceId");

            entity.HasIndex(e => e.RelatedTaskId, "IX_RelatedTaskId");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.BusinessProcess)
                .HasForeignKey<BusinessProcess>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.BusinessProcess_dbo.BaseTable_Id");

            entity.HasOne(d => d.Owner).WithMany(p => p.InverseOwner)
                .HasForeignKey(d => d.OwnerId)
                .HasConstraintName("FK_dbo.BusinessProcess_dbo.BusinessProcess_OwnerId");

            entity.HasOne(d => d.OwnerSubProcessTrace).WithMany(p => p.BusinessProcesss)
                .HasForeignKey(d => d.OwnerSubProcessTraceId)
                .HasConstraintName("FK_dbo.BusinessProcess_dbo.WorkFlowTrace_OwnerSubProcessTraceId");

            entity.HasOne(d => d.RelatedTask).WithMany(p => p.BusinessProcesss)
                .HasForeignKey(d => d.RelatedTaskId)
                .HasConstraintName("FK_dbo.BusinessProcess_dbo.Task_RelatedTaskId");
        });

        modelBuilder.Entity<ConditionOption>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.ConditionOption");

            entity.ToTable("ConditionOption");

            entity.HasIndex(e => e.ConditionId, "IX_ConditionId");

            entity.HasIndex(e => e.Id, "IX_Id");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Value).HasMaxLength(200);

            entity.HasOne(d => d.Condition).WithMany(p => p.ConditionOptions)
                .HasForeignKey(d => d.ConditionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.ConditionOption_dbo.Condition_ConditionId");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.ConditionOption)
                .HasForeignKey<ConditionOption>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.ConditionOption_dbo.Process_Id");
        });

        modelBuilder.Entity<Condition>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Condition");

            entity.ToTable("Condition");

            entity.HasIndex(e => e.Id, "IX_Id");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.VariableName).HasMaxLength(20);

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Condition)
                .HasForeignKey<Condition>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.Condition_dbo.Process_Id");
        });

        modelBuilder.Entity<Counter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_HangFire_Counter");

            entity.ToTable("Counter", "HangFire");

            entity.HasIndex(e => e.Key, "IX_HangFire_Counter_Key");

            entity.Property(e => e.ExpireAt).HasColumnType("datetime");
            entity.Property(e => e.Key)
                .IsRequired()
                .HasMaxLength(100);
        });

        modelBuilder.Entity<DecisionMethod>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.DecisionMethod");

            entity.ToTable("DecisionMethod");

            entity.HasIndex(e => e.Id, "IX_Id");

            entity.HasIndex(e => new { e.TaskId, e.MethodName }, "IX_MetotTanim").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.MethodDescription).HasMaxLength(500);
            entity.Property(e => e.MethodName)
                .IsRequired()
                .HasMaxLength(100);

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.DecisionMethod)
                .HasForeignKey<DecisionMethod>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.DecisionMethod_dbo.BaseTable_Id");

            entity.HasOne(d => d.Task).WithMany(p => p.DecisionMethods)
                .HasForeignKey(d => d.TaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.DecisionMethod_dbo.Task_TaskId");
        });

        modelBuilder.Entity<DecisionPoint>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.DecisionPoint");

            entity.ToTable("DecisionPoint");

            entity.HasIndex(e => e.CancelProcessId, "IX_CancelProcessId");

            entity.HasIndex(e => e.DecisionMethodId, "IX_DecisionMethodId");

            entity.HasIndex(e => e.Id, "IX_Id");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.CancelProcess).WithMany(p => p.DecisionPoints)
                .HasForeignKey(d => d.CancelProcessId)
                .HasConstraintName("FK_dbo.DecisionPoint_dbo.Process_CancelProcessId");

            entity.HasOne(d => d.DecisionMethod).WithMany(p => p.DecisionPoints)
                .HasForeignKey(d => d.DecisionMethodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.DecisionPoint_dbo.DecisionMethod_DecisionMethodId");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.DecisionPoint)
                .HasForeignKey<DecisionPoint>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.DecisionPoint_dbo.Condition_Id");
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Document");

            entity.ToTable("Document");

            entity.HasIndex(e => e.MediaName, "IX_FileMediaName").IsUnique();

            entity.HasIndex(e => new { e.OwnerId, e.FileName }, "IX_FileOwner").IsUnique();

            entity.HasIndex(e => e.Id, "IX_Id");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Extension)
                .IsRequired()
                .HasMaxLength(10);
            entity.Property(e => e.FileName)
                .IsRequired()
                .HasMaxLength(255);
            entity.Property(e => e.MediaName)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.MimeType)
                .IsRequired()
                .HasMaxLength(255);

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.DocumentIdNavigation)
                .HasForeignKey<Document>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.Document_dbo.BaseTable_Id");

            entity.HasOne(d => d.Owner).WithMany(p => p.Documents)
                .HasForeignKey(d => d.OwnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.Document_dbo.BaseTable_OwnerId");
        });

        modelBuilder.Entity<FormView>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.FormView");

            entity.ToTable("FormView");

            entity.HasIndex(e => new { e.TaskId, e.FormName }, "IX_FormTanim").IsUnique();

            entity.HasIndex(e => new { e.TaskId, e.ViewName }, "IX_FormViewName").IsUnique();

            entity.HasIndex(e => e.Id, "IX_Id");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.FormDescription).HasMaxLength(500);
            entity.Property(e => e.FormName)
                .IsRequired()
                .HasMaxLength(50);
            entity.Property(e => e.ViewName)
                .IsRequired()
                .HasMaxLength(50);

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.FormView)
                .HasForeignKey<FormView>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.FormView_dbo.BaseTable_Id");

            entity.HasOne(d => d.Task).WithMany(p => p.FormViews)
                .HasForeignKey(d => d.TaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.FormView_dbo.Task_TaskId");
        });

        modelBuilder.Entity<Hash>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_HangFire_Hash");

            entity.ToTable("Hash", "HangFire");

            entity.HasIndex(e => e.ExpireAt, "IX_HangFire_Hash_ExpireAt");

            entity.HasIndex(e => e.Key, "IX_HangFire_Hash_Key");

            entity.HasIndex(e => new { e.Key, e.Field }, "UX_HangFire_Hash_Key_Field").IsUnique();

            entity.Property(e => e.Field)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.Key)
                .IsRequired()
                .HasMaxLength(100);
        });

        modelBuilder.Entity<Job>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_HangFire_Job");

            entity.ToTable("Job", "HangFire");

            entity.HasIndex(e => e.ExpireAt, "IX_HangFire_Job_ExpireAt");

            entity.HasIndex(e => e.StateName, "IX_HangFire_Job_StateName");

            entity.Property(e => e.Arguments).IsRequired();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.ExpireAt).HasColumnType("datetime");
            entity.Property(e => e.InvocationData).IsRequired();
            entity.Property(e => e.StateName).HasMaxLength(20);
        });

        modelBuilder.Entity<JobParameter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_HangFire_JobParameter");

            entity.ToTable("JobParameter", "HangFire");

            entity.HasIndex(e => new { e.JobId, e.Name }, "IX_HangFire_JobParameter_JobIdAndName");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(40);

            entity.HasOne(d => d.Job).WithMany(p => p.JobParameters)
                .HasForeignKey(d => d.JobId)
                .HasConstraintName("FK_HangFire_JobParameter_Job");
        });

        modelBuilder.Entity<JobQueue>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_HangFire_JobQueue");

            entity.ToTable("JobQueue", "HangFire");

            entity.HasIndex(e => new { e.Queue, e.FetchedAt }, "IX_HangFire_JobQueue_QueueAndFetchedAt");

            entity.Property(e => e.FetchedAt).HasColumnType("datetime");
            entity.Property(e => e.Queue)
                .IsRequired()
                .HasMaxLength(50);
        });

        modelBuilder.Entity<List>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_HangFire_List");

            entity.ToTable("List", "HangFire");

            entity.HasIndex(e => e.ExpireAt, "IX_HangFire_List_ExpireAt");

            entity.HasIndex(e => e.Key, "IX_HangFire_List_Key");

            entity.Property(e => e.ExpireAt).HasColumnType("datetime");
            entity.Property(e => e.Key)
                .IsRequired()
                .HasMaxLength(100);
        });

        modelBuilder.Entity<MigrationHistory>(entity =>
        {
            entity.HasKey(e => new { e.MigrationId, e.ContextKey }).HasName("PK_dbo.__MigrationHistory");

            entity.ToTable("__MigrationHistory");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ContextKey).HasMaxLength(300);
            entity.Property(e => e.Model).IsRequired();
            entity.Property(e => e.ProductVersion)
                .IsRequired()
                .HasMaxLength(32);
        });

        modelBuilder.Entity<ProcessMonitoringRole>(entity =>
        {
            entity.HasKey(e => new { e.ProcessId, e.ProjectRole }).HasName("PK_dbo.ProcessMonitoringRole");

            entity.ToTable("ProcessMonitoringRole");

            entity.HasIndex(e => e.ProcessId, "IX_ProcessId");

            entity.HasOne(d => d.Process).WithMany(p => p.ProcessMonitoringRoles)
                .HasForeignKey(d => d.ProcessId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.ProcessMonitoringRole_dbo.Process_ProcessId");
        });

        modelBuilder.Entity<Process>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Process");

            entity.ToTable("Process");

            entity.HasIndex(e => e.FormViewId, "IX_FormViewId");

            entity.HasIndex(e => e.ProcessUniqueCode, "IX_GorevIslemKodu").IsUnique();

            entity.HasIndex(e => e.Id, "IX_Id");

            entity.HasIndex(e => e.NextProcessId, "IX_NextProcessId");

            entity.HasIndex(e => e.TaskId, "IX_TaskId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.MessageForMonitor).HasMaxLength(100);
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.ProcessUniqueCode)
                .IsRequired()
                .HasMaxLength(100);

            entity.HasOne(d => d.FormView).WithMany(p => p.Processs)
                .HasForeignKey(d => d.FormViewId)
                .HasConstraintName("FK_dbo.Process_dbo.FormView_FormViewId");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Process)
                .HasForeignKey<Process>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.Process_dbo.BaseTable_Id");

            entity.HasOne(d => d.NextProcess).WithMany(p => p.InverseNextProcess)
                .HasForeignKey(d => d.NextProcessId)
                .HasConstraintName("FK_dbo.Process_dbo.Process_NextProcessId");

            entity.HasOne(d => d.Task).WithMany(p => p.Processs)
                .HasForeignKey(d => d.TaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.Process_dbo.Task_TaskId");
        });

        modelBuilder.Entity<Schema>(entity =>
        {
            entity.HasKey(e => e.Version).HasName("PK_HangFire_Schema");

            entity.ToTable("Schema", "HangFire");

            entity.Property(e => e.Version).ValueGeneratedNever();
        });

        modelBuilder.Entity<Server>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_HangFire_Server");

            entity.ToTable("Server", "HangFire");

            entity.Property(e => e.Id).HasMaxLength(100);
            entity.Property(e => e.LastHeartbeat).HasColumnType("datetime");
        });

        modelBuilder.Entity<Set>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_HangFire_Set");

            entity.ToTable("Set", "HangFire");

            entity.HasIndex(e => e.ExpireAt, "IX_HangFire_Set_ExpireAt");

            entity.HasIndex(e => e.Key, "IX_HangFire_Set_Key");

            entity.HasIndex(e => new { e.Key, e.Value }, "UX_HangFire_Set_KeyAndValue").IsUnique();

            entity.Property(e => e.ExpireAt).HasColumnType("datetime");
            entity.Property(e => e.Key)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.Value)
                .IsRequired()
                .HasMaxLength(256);
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_HangFire_State");

            entity.ToTable("State", "HangFire");

            entity.HasIndex(e => e.JobId, "IX_HangFire_State_JobId");

            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(20);
            entity.Property(e => e.Reason).HasMaxLength(100);

            entity.HasOne(d => d.Job).WithMany(p => p.States)
                .HasForeignKey(d => d.JobId)
                .HasConstraintName("FK_HangFire_State_Job");
        });

        modelBuilder.Entity<SubProcess>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.SubProcess");

            entity.ToTable("SubProcess");

            entity.HasIndex(e => e.Id, "IX_Id");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.SubProcess)
                .HasForeignKey<SubProcess>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.SubProcess_dbo.Process_Id");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.Task");

            entity.ToTable("Task");

            entity.HasIndex(e => e.Id, "IX_Id");

            entity.HasIndex(e => e.StartingProcessId, "IX_StartingProcessId");

            entity.HasIndex(e => e.TopTaskId, "IX_TopTaskId");

            entity.HasIndex(e => e.WorkFlowId, "IX_WorkFlowId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.MethodServiceName).HasMaxLength(100);
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Task)
                .HasForeignKey<Task>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.Task_dbo.BaseTable_Id");

            entity.HasOne(d => d.StartingProcess).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.StartingProcessId)
                .HasConstraintName("FK_dbo.Task_dbo.Process_StartingProcessId");

            entity.HasOne(d => d.TopTask).WithMany(p => p.InverseTopTask)
                .HasForeignKey(d => d.TopTaskId)
                .HasConstraintName("FK_dbo.Task_dbo.Task_TopTaskId");

            entity.HasOne(d => d.WorkFlow).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.WorkFlowId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.Task_dbo.WorkFlow_WorkFlowId");
        });

        modelBuilder.Entity<TestForm>(entity =>
        {
            entity.HasKey(e => e.OwnerId).HasName("PK_dbo.TestForm");

            entity.ToTable("TestForm");

            entity.HasIndex(e => e.OwnerId, "IX_OwnerId");

            entity.Property(e => e.OwnerId).ValueGeneratedNever();

            entity.HasOne(d => d.Owner).WithOne(p => p.TestForm)
                .HasForeignKey<TestForm>(d => d.OwnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.TestForm_dbo.BaseTable_OwnerId");
        });

        modelBuilder.Entity<WorkFlowEngineVariable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.WorkFlowEngineVariable");

            entity.ToTable("WorkFlowEngineVariable");
        });

        modelBuilder.Entity<WorkFlow>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.WorkFlow");

            entity.ToTable("WorkFlow");

            entity.HasIndex(e => e.Id, "IX_Id");

            entity.HasIndex(e => e.Name, "IX_IsAkisiTanim").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.WorkFlow)
                .HasForeignKey<WorkFlow>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.WorkFlow_dbo.BaseTable_Id");
        });

        modelBuilder.Entity<WorkFlowTrace>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.WorkFlowTrace");

            entity.ToTable("WorkFlowTrace");

            entity.HasIndex(e => e.ConditionOptionId, "IX_ConditionOptionId");

            entity.HasIndex(e => e.Id, "IX_Id");

            entity.HasIndex(e => e.OwnerId, "IX_OwnerId");

            entity.HasIndex(e => e.ProcessId, "IX_ProcessId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.JobId).HasMaxLength(50);

            entity.HasOne(d => d.ConditionOption).WithMany(p => p.WorkFlowTraces)
                .HasForeignKey(d => d.ConditionOptionId)
                .HasConstraintName("FK_dbo.WorkFlowTrace_dbo.ConditionOption_ConditionOptionId");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.WorkFlowTraceIdNavigation)
                .HasForeignKey<WorkFlowTrace>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.WorkFlowTrace_dbo.BaseTable_Id");

            entity.HasOne(d => d.Owner).WithMany(p => p.WorkFlowTraces)
                .HasForeignKey(d => d.OwnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.WorkFlowTrace_dbo.BaseTable_OwnerId");

            entity.HasOne(d => d.Process).WithMany(p => p.WorkFlowTraces)
                .HasForeignKey(d => d.ProcessId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_dbo.WorkFlowTrace_dbo.Process_ProcessId");
        });

        modelBuilder.Entity<WorkflowApprovalHistory>(entity =>
        {
            entity.HasKey(e => e.Id).IsClustered(false);

            entity.ToTable("WorkflowApprovalHistory");

            entity.HasIndex(e => e.IdentityId, "IX_IdentityId");

            entity.HasIndex(e => e.ProcessId, "IX_ProcessId_Clustered").IsClustered();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DestinationState)
                .IsRequired()
                .HasMaxLength(1024);
            entity.Property(e => e.IdentityId).HasMaxLength(256);
            entity.Property(e => e.InitialState)
                .IsRequired()
                .HasMaxLength(1024);
            entity.Property(e => e.TransitionTime).HasColumnType("datetime");
            entity.Property(e => e.TriggerName).HasMaxLength(1024);
        });

        modelBuilder.Entity<WorkflowGlobalParameter>(entity =>
        {
            entity.HasKey(e => e.Id).IsClustered(false);

            entity.ToTable("WorkflowGlobalParameter");

            entity.HasIndex(e => new { e.Type, e.Name }, "IX_Type_Name_Clustered")
                .IsUnique()
                .IsClustered();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(128);
            entity.Property(e => e.Type)
                .IsRequired()
                .HasMaxLength(306);
            entity.Property(e => e.Value).IsRequired();
        });

        modelBuilder.Entity<WorkflowInbox>(entity =>
        {
            entity.HasKey(e => e.Id).IsClustered(false);

            entity.ToTable("WorkflowInbox");

            entity.HasIndex(e => e.IdentityId, "IX_IdentityId_Clustered").IsClustered();

            entity.HasIndex(e => e.ProcessId, "IX_ProcessId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.AddingDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.AvailableCommands)
                .IsRequired()
                .HasDefaultValueSql("('')");
            entity.Property(e => e.IdentityId)
                .IsRequired()
                .HasMaxLength(256);
        });

        modelBuilder.Entity<WorkflowProcessAssignment>(entity =>
        {
            entity.HasKey(e => e.Id).IsClustered(false);

            entity.ToTable("WorkflowProcessAssignment");

            entity.HasIndex(e => e.AssignmentCode, "IX_Assignment_AssignmentCode");

            entity.HasIndex(e => e.Executor, "IX_Assignment_Executor");

            entity.HasIndex(e => e.ProcessId, "IX_Assignment_ProcessId");

            entity.HasIndex(e => new { e.ProcessId, e.Executor }, "IX_Assignment_ProcessId_Executor");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.AssignmentCode)
                .IsRequired()
                .HasMaxLength(2048);
            entity.Property(e => e.DateCreation).HasColumnType("datetime");
            entity.Property(e => e.DateFinish).HasColumnType("datetime");
            entity.Property(e => e.DateStart).HasColumnType("datetime");
            entity.Property(e => e.DeadlineToComplete).HasColumnType("datetime");
            entity.Property(e => e.DeadlineToStart).HasColumnType("datetime");
            entity.Property(e => e.Executor)
                .IsRequired()
                .HasMaxLength(256);
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.StatusState).IsRequired();
        });

        modelBuilder.Entity<WorkflowProcessInstance>(entity =>
        {
            entity.ToTable("WorkflowProcessInstance");

            entity.HasIndex(e => e.RootProcessId, "IX_RootProcessId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ActivityName).IsRequired();
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.LastTransitionDate).HasColumnType("datetime");
            entity.Property(e => e.TenantId).HasMaxLength(1024);
        });

        modelBuilder.Entity<WorkflowProcessInstancePersistence>(entity =>
        {
            entity.HasKey(e => e.Id).IsClustered(false);

            entity.ToTable("WorkflowProcessInstancePersistence");

            entity.HasIndex(e => e.ProcessId, "IX_ProcessId_Clustered").IsClustered();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ParameterName).IsRequired();
            entity.Property(e => e.Value).IsRequired();
        });

        modelBuilder.Entity<WorkflowProcessInstanceStatus>(entity =>
        {
            entity.ToTable("WorkflowProcessInstanceStatus");

            entity.HasIndex(e => e.Status, "IX_WorkflowProcessInstanceStatus_Status");

            entity.HasIndex(e => new { e.Status, e.RuntimeId }, "IX_WorkflowProcessInstanceStatus_Status_Runtime");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.RuntimeId).IsRequired();
            entity.Property(e => e.SetTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<WorkflowProcessScheme>(entity =>
        {
            entity.ToTable("WorkflowProcessScheme");

            entity.HasIndex(e => new { e.SchemeCode, e.DefiningParametersHash, e.IsObsolete }, "IX_SchemeCode_Hash_IsObsolete");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DefiningParameters)
                .IsRequired()
                .HasColumnType("ntext");
            entity.Property(e => e.DefiningParametersHash)
                .IsRequired()
                .HasMaxLength(24);
            entity.Property(e => e.RootSchemeCode).HasMaxLength(256);
            entity.Property(e => e.Scheme)
                .IsRequired()
                .HasColumnType("ntext");
            entity.Property(e => e.SchemeCode)
                .IsRequired()
                .HasMaxLength(256);
        });

        modelBuilder.Entity<WorkflowProcessTimer>(entity =>
        {
            entity.HasKey(e => e.Id).IsClustered(false);

            entity.ToTable("WorkflowProcessTimer");

            entity.HasIndex(e => e.NextExecutionDateTime, "IX_NextExecutionDateTime_Clustered").IsClustered();

            entity.HasIndex(e => e.ProcessId, "IX_ProcessId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.NextExecutionDateTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<WorkflowProcessTransitionHistory>(entity =>
        {
            entity.HasKey(e => e.Id).IsClustered(false);

            entity.ToTable("WorkflowProcessTransitionHistory");

            entity.HasIndex(e => e.ExecutorIdentityId, "IX_ExecutorIdentityId");

            entity.HasIndex(e => e.ProcessId, "IX_ProcessId_Clustered").IsClustered();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ActorIdentityId).HasMaxLength(256);
            entity.Property(e => e.ActorName).HasMaxLength(256);
            entity.Property(e => e.ExecutorIdentityId).HasMaxLength(256);
            entity.Property(e => e.ExecutorName).HasMaxLength(256);
            entity.Property(e => e.FromActivityName).IsRequired();
            entity.Property(e => e.StartTransitionTime).HasColumnType("datetime");
            entity.Property(e => e.ToActivityName).IsRequired();
            entity.Property(e => e.TransitionClassifier).IsRequired();
            entity.Property(e => e.TransitionTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<WorkflowRuntime>(entity =>
        {
            entity.HasKey(e => e.RuntimeId);

            entity.ToTable("WorkflowRuntime");

            entity.Property(e => e.LastAliveSignal).HasColumnType("datetime");
            entity.Property(e => e.NextServiceTimerTime).HasColumnType("datetime");
            entity.Property(e => e.NextTimerTime).HasColumnType("datetime");
            entity.Property(e => e.RestorerId).HasMaxLength(450);
        });

        modelBuilder.Entity<WorkflowScheme>(entity =>
        {
            entity.HasKey(e => e.Code);

            entity.ToTable("WorkflowScheme");

            entity.Property(e => e.Code).HasMaxLength(256);
            entity.Property(e => e.Scheme).IsRequired();
        });

        modelBuilder.Entity<WorkflowSync>(entity =>
        {
            entity.HasKey(e => e.Name);

            entity.ToTable("WorkflowSync");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
