using System;
using System.Collections.Generic;

namespace WFE.Core.Migration.EFCore.Models;

public partial class Job
{
    public int Id { get; set; }

    public int? StateId { get; set; }

    public string StateName { get; set; }

    public string InvocationData { get; set; }

    public string Arguments { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? ExpireAt { get; set; }

    public virtual ICollection<JobParameter> JobParameters { get; } = new List<JobParameter>();

    public virtual ICollection<State> States { get; } = new List<State>();
}
