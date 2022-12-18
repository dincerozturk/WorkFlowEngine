using System;
using System.Collections.Generic;

namespace WFE.Core.Migration.EFCore.Models;

public partial class WorkFlow
{
    public int Id { get; set; }

    public string Name { get; set; }

    public virtual BaseTable IdNavigation { get; set; }

    public virtual ICollection<Task> Tasks { get; } = new List<Task>();
}
