using System.Collections.Generic;

namespace WorkFlowManager.Common.Tables
{
    public class Task : BaseTable
    {
        public Task()
        {
            ProcessList = new List<Process>();
        }

        public void AddProcess<T>(T process) where T : Process
        {
            ProcessList.Add(process);
        }
        public int WorkFlowId { get; set; }
        public virtual WorkFlow WorkFlow { get; set; }
        public string Name { get; set; }

        public int? StartingProcessId { get; set; }
        public virtual Process StartingProcess { get; set; }

        public virtual ICollection<Process> ProcessList { get; set; }

        public virtual ICollection<DecisionMethod> DecisionMethodList { get; set; }
        public virtual ICollection<FormView> FormViewList { get; set; }

        public string WorkFlowDiagram { get; set; }

        public string MethodServiceName { get; set; }
        public string Controller { get; set; }
        public string SpecialFormTemplateView { get; set; }

        public int? TopTaskId { get; set; }
        public virtual Task TopTask { get; set; }

        public virtual ICollection<Task> SubTaskList { get; set; }
    }
}
