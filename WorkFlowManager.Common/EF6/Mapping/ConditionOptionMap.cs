using WorkFlowManager.Common.Tables;

namespace WorkFlowManager.Common.Mapping
{
    public class ConditionOptionMap : BaseTableMap<ConditionOption>
    {
        public ConditionOptionMap()
        {
            ToTable(tableName: "ConditionOptionTbl");

            HasRequired(s => s.Condition)
                .WithMany(s => s.ConditionOptions)
                .WillCascadeOnDelete(false);

            Property(t => t.Value)
                .HasMaxLength(200);
        }
    }
}
