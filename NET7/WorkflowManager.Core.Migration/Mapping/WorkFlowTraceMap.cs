using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkFlowManager.Common.Tables;

namespace WorkFlowManager.Common.Mapping
{
    public class WorkFlowTraceMap : BaseTableMap<WorkFlowTrace>
    {
        //public WorkFlowTraceMap()
        //{
        //    ToTable(tableName: "WorkFlowTraceTbl");

        //    HasRequired(s => s.Owner)
        //        .WithMany(s => s.WorkFlowTraces)
        //        .WillCascadeOnDelete(false);

        //    Property(s => s.Description)
        //        .HasMaxLength(100);

        //    Property(s => s.JobId)
        //        .HasMaxLength(50);


        //}
        public override void Configure(EntityTypeBuilder<WorkFlowTrace> builder)
        {
            throw new NotImplementedException();
        }
    }
}
