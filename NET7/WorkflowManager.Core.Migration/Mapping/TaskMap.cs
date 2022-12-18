using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkFlowManager.Common.Tables;

namespace WorkFlowManager.Common.Mapping
{
    public class TaskMap : BaseTableMap<WorkFlowManager.Common.Tables.Task>
    {
        //public TaskMap()
        //{
        //    ToTable(tableName: "TaskTbl");

        //    //one-to-many
        //    HasRequired(s => s.WorkFlow) // Gorev bir iş akışına bağlı olmalı
        //        .WithMany(s => s.Tasks) // İş akışının birden fazla görevi olabilir
        //        .WillCascadeOnDelete(false);

        //    Property(t => t.Name)
        //        .IsRequired()
        //        .HasMaxLength(100);

        //    Property(t => t.MethodServiceName)
        //        .HasMaxLength(100);

        //    HasOptional(s => s.TopTask)
        //        .WithMany(s => s.Tasks)
        //        .HasForeignKey(s => s.TopTaskId)
        //        .WillCascadeOnDelete(false);

        //}
        public override void Configure(EntityTypeBuilder<WorkFlowManager.Common.Tables.Task> builder)
        {
            throw new NotImplementedException();
        }
    }
}
