using WorkFlowManager.Common.Tables;

namespace WorkFlowManager.Common.Mapping
{
    public class BaseTableTableMap : BaseTableMap<ABaseTable>
    {
        public BaseTableTableMap()
        {

            ToTable("BaseTableTbl");
        }
    }
}
