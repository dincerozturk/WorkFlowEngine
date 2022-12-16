using System.Collections.Generic;
using WorkFlowManager.Common.Enums;

namespace WorkFlowManager.Common.Tables
{
    public class WorkFlowTrace : ABaseTable
    {
        public int OwnerId { get; set; }
        public virtual ABaseTable Owner { get; set; }
        public int ProcessId { get; set; }
        public virtual Process Process { get; set; }
        public int? ConditionOptionId { get; set; }
        public virtual ConditionOption ConditionOption { get; set; }
        public string Description { get; set; }
        public int ProcessStatus { get; set; }
        public string JobId { get; set; }

        public bool IsCondition => Process.GetType() == typeof(Condition);

        // SubProcesses
        public virtual ICollection<BusinessProcess> BusinessProcesses { get; set; }
    }
}
