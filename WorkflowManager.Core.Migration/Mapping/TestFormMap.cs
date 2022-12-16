using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using System.Data.Entity.ModelConfiguration;
using WorkFlowManager.Common.Tables;

namespace WorkFlowManager.Common.Mapping
{

    public class TestFormMap : IEntityTypeConfiguration<TestForm>
    {
        //public TestFormMap()
        //{

        //    ToTable("TestFormTbl");
        //    HasKey(x => x.OwnerId);

        //    HasRequired(s => s.Owner)
        //       .WithRequiredDependent()
        //       .WillCascadeOnDelete(false);
        //}
        public void Configure(EntityTypeBuilder<TestForm> builder)
        {
            throw new NotImplementedException();
        }
    }
}
