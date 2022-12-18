using System;
using System.Collections.Generic;

namespace WFE.Core.Migration.EFCore.Models;

public partial class ConditionOption
{
    public int Id { get; set; }

    public int ConditionId { get; set; }

    public string Value { get; set; }

    public virtual Condition Condition { get; set; }

    public virtual Process IdNavigation { get; set; }

    public virtual ICollection<WorkFlowTrace> WorkFlowTraces { get; } = new List<WorkFlowTrace>();
}
