using System;
using System.Collections.Generic;

namespace WFE.Core.Migration.EFCore.Models;

public partial class DecisionMethod
{
    public int Id { get; set; }

    public int TaskId { get; set; }

    public string MethodFunction { get; set; }

    public string MethodName { get; set; }

    public string MethodDescription { get; set; }

    public bool Completed { get; set; }

    public virtual ICollection<DecisionPoint> DecisionPoints { get; } = new List<DecisionPoint>();

    public virtual BaseTable IdNavigation { get; set; }

    public virtual Task Task { get; set; }
}
