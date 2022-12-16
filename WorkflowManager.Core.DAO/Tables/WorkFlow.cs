using System.Collections.Generic;

namespace WorkFlowManager.Common.Tables
{
    public class WorkFlow : ABaseTable
    {
        public virtual ICollection<Task> Tasks { get; set; }
        public string Name { get; set; }
    }

}
