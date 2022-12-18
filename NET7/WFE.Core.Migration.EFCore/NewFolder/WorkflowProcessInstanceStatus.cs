using System;
using System.Collections.Generic;

namespace WFE.Core.Migration.EFCore.Models;

public partial class WorkflowProcessInstanceStatus
{
    public Guid Id { get; set; }

    public byte Status { get; set; }

    public Guid Lock { get; set; }

    public string RuntimeId { get; set; }

    public DateTime SetTime { get; set; }
}
