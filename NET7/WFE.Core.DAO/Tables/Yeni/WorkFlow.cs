using System.Collections.Generic;

namespace WorkFlowManager.Common.Tables
{
    public class WorkFlow : BaseTable
    {
        public virtual ICollection<Task> TaskList { get; set; }
        public string Name { get; set; }
    }

}
