using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WorkFlowManager.Common.Tables;

namespace WorkFlowManager.Common.Mapping
{
    public class BaseTableTableMap : BaseTableMap<BaseTable>
    {
        //public BaseTableTableMap()
        //{

        //    ToTable("BaseTableTbl");
        //}
        public override void Configure(EntityTypeBuilder<BaseTable> builder)
        {
            throw new NotImplementedException();
        }
    }
}
