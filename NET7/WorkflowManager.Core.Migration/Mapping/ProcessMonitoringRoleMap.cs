using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using System.Data.Entity.ModelConfiguration;
using WorkFlowManager.Common.Tables;

namespace WorkFlowManager.Common.Mapping
{
    public class ProcessMonitoringRoleMap : IEntityTypeConfiguration<ProcessMonitoringRole>
    {
        //public ProcessMonitoringRoleMap()
        //{
        //    HasKey(k => new { k.ProcessId, k.ProjectRole });

        //    ToTable(tableName: "ProcessMonitoringRoleTbl");

        //    HasRequired(s => s.Process)
        //        .WithMany(s => s.ProcessMonitoringRoles)
        //        .WillCascadeOnDelete(false);
        //}
        public void Configure(EntityTypeBuilder<ProcessMonitoringRole> builder)
        {
            throw new NotImplementedException();
        }
    }
}
