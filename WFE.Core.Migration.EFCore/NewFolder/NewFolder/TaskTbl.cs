using System;
using System.Collections.Generic;

namespace WFE.Core.Migration.EFCore.Models;

public partial class Task
{
    public int Id { get; set; }

    public int WorkFlowId { get; set; }

    public string Name { get; set; }

    public int? StartingProcessId { get; set; }

    public string WorkFlowDiagram { get; set; }

    public string MethodServiceName { get; set; }

    public string Controller { get; set; }

    public string SpecialFormTemplateView { get; set; }

    public int? TopTaskId { get; set; }

    public virtual ICollection<BusinessProcess> BusinessProcesss { get; } = new List<BusinessProcess>();

    public virtual ICollection<DecisionMethod> DecisionMethods { get; } = new List<DecisionMethod>();

    public virtual ICollection<FormView> FormViews { get; } = new List<FormView>();

    public virtual BaseTable IdNavigation { get; set; }

    public virtual ICollection<Task> InverseTopTask { get; } = new List<Task>();

    public virtual ICollection<Process> Processs { get; } = new List<Process>();

    public virtual Process StartingProcess { get; set; }

    public virtual Task TopTask { get; set; }

    public virtual WorkFlow WorkFlow { get; set; }
}
