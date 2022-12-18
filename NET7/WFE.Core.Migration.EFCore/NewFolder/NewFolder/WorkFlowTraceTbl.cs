using System;
using System.Collections.Generic;

namespace WFE.Core.Migration.EFCore.Models;

public partial class WorkFlowTrace
{
    public int Id { get; set; }

    public int OwnerId { get; set; }

    public int ProcessId { get; set; }

    public int? ConditionOptionId { get; set; }

    public string Description { get; set; }

    public int ProcessStatus { get; set; }

    public string JobId { get; set; }

    public virtual ICollection<BusinessProcess> BusinessProcesss { get; } = new List<BusinessProcess>();

    public virtual ConditionOption ConditionOption { get; set; }

    public virtual BaseTable IdNavigation { get; set; }

    public virtual BaseTable Owner { get; set; }

    public virtual Process Process { get; set; }
}
