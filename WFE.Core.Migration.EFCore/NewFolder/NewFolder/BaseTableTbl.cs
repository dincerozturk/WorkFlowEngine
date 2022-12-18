using System;
using System.Collections.Generic;

namespace WFE.Core.Migration.EFCore.Models;

public partial class BaseTable : ABaseTable
{
    public virtual BusinessProcess BusinessProcess { get; set; }

    public virtual DecisionMethod DecisionMethod { get; set; }

    public virtual Document DocumentIdNavigation { get; set; }

    

    public virtual FormView FormView { get; set; }

    public virtual Process Process { get; set; }

    public virtual Task Task { get; set; }

    public virtual TestForm TestForm { get; set; }

    public virtual WorkFlow WorkFlow { get; set; }

    public virtual WorkFlowTrace WorkFlowTraceIdNavigation { get; set; }

    //public virtual ICollection<Document> Documents { get; } = new List<Document>();
    //public virtual ICollection<WorkFlowTrace> WorkFlowTraces { get; } = new List<WorkFlowTrace>();
}
