using System;
using System.Collections.Generic;

namespace WFE.Core.Migration.EFCore.Models;

public partial class Process : ABaseTable
{
    public int Id { get; set; }

    public int AssignedRole { get; set; }

    public int? FormViewId { get; set; }

    public string ProcessUniqueCode { get; set; }

    public int TaskId { get; set; }

    public int? NextProcessId { get; set; }

    public string NextText { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string SpecialFormAnalysis { get; set; }

    public bool IsDescriptionMandatory { get; set; }

    public string MessageForMonitor { get; set; }

    public virtual ConditionOption ConditionOption { get; set; }

    public virtual Condition Condition { get; set; }

    public virtual ICollection<DecisionPoint> DecisionPoints { get; } = new List<DecisionPoint>();

    public virtual FormView FormView { get; set; }

    public virtual BaseTable IdNavigation { get; set; }

    public virtual ICollection<Process> InverseNextProcess { get; } = new List<Process>();

    public virtual Process NextProcess { get; set; }

    public virtual ICollection<ProcessMonitoringRole> ProcessMonitoringRoles { get; } = new List<ProcessMonitoringRole>();

    public virtual SubProcess SubProcess { get; set; }

    public virtual Task Task { get; set; }

    public virtual ICollection<Task> Tasks { get; } = new List<Task>();

    public virtual ICollection<WorkFlowTrace> WorkFlowTraces { get; } = new List<WorkFlowTrace>();
}
