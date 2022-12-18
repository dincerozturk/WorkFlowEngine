using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using WorkFlowManager.Common.Tables;

namespace WorkFlowManager.Common.Mapping
{
    public class BaseTableMap<T> : EntityTypeConfiguration<T> where T : ABaseTable
    {
        public BaseTableMap()
        {
            // primary key belirtiyoruz.
            HasKey(x => x.Id);
            Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        }
    }
}
