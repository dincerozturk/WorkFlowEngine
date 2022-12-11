namespace WorkFlowManager.Common.Tables
{
    public class BusinessProcess : ABaseTable
    {
        public int? OwnerId { get; set; }
        public virtual BusinessProcess Owner { get; set; }
        public string Name { get; set; }

        public int? OwnerSubProcessTraceId { get; set; }
        public virtual WorkFlowTrace OwnerSubProcessTrace { get; set; }

        public int? RelatedTaskId {  get; set; }
        public virtual Task RelatedTask { get; set; }
    }
}
