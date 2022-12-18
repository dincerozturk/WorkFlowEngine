using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkFlowManager.Common.Tables;

namespace WorkFlowManager.Common.Mapping
{
    public class DecisionPointMap : BaseTableMap<DecisionPoint>
    {
        //public DecisionPointMap()
        //{
        //    ToTable(tableName: "DecisionPointTbl");
        //}
        public override void Configure(EntityTypeBuilder<DecisionPoint> builder)
        {
            throw new NotImplementedException();
        }
    }
}
