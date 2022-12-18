using System.Collections.Generic;
using WorkFlowManager.Common.Enums;

namespace WorkFlowManager.Common.Tables
{
    public class Condition : Process
    {
        public Condition()
        {
        }
        public Condition(Task task, string name, ProjectRole assignedRole, string variableName = null, string description = null, FormView formView = null) : base(task, name, assignedRole, description, formView)
        {
            ConditionOptions = new List<ConditionOption>();
            VariableName = variableName;
            task.AddProcess(this);
        }

        public virtual ICollection<ConditionOption> ConditionOptions { get; set; }

        public void AddOption(ConditionOption optionList)
        {
            ConditionOptions.Add(optionList);
        }

        public string VariableName { get; set; }
    }
}
