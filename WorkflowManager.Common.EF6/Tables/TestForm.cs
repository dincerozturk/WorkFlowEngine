namespace WorkFlowManager.Common.Tables
{
    public class TestForm
    {
        public int OwnerId { get; set; }
        public virtual ABaseTable Owner { get; set; }
        public int Age { get; set; }
    }
}
