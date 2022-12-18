using System;
using System.Collections.Generic;

namespace WFE.Core.Migration.EFCore.Models;

public partial class Condition
{
    public int Id { get; set; }

    public string VariableName { get; set; }

    public virtual ICollection<ConditionOption> ConditionOptions { get; } = new List<ConditionOption>();

    public virtual DecisionPoint DecisionPoint { get; set; }

    public virtual Process IdNavigation { get; set; }
}
