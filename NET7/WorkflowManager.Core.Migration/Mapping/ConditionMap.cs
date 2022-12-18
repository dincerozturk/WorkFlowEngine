using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkFlowManager.Common.Tables;

namespace WorkFlowManager.Common.Mapping
{
    public class ConditionMap : BaseTableMap<Condition>
    {
        //public ConditionMap()
        //{
        //    ToTable("ConditionTbl");

        //    Property(t => t.VariableName)
        //        .HasMaxLength(20);
        //}
        public override void Configure(EntityTypeBuilder<Condition> builder)
        {
            throw new NotImplementedException();
        }
    }
}
