using System;
using System.Collections.Generic;

namespace WFE.Core.Migration.EFCore.Models;

public partial class WorkflowRuntime
{
    public string RuntimeId { get; set; }

    public Guid Lock { get; set; }

    public byte Status { get; set; }

    public string RestorerId { get; set; }

    public DateTime? NextTimerTime { get; set; }

    public DateTime? NextServiceTimerTime { get; set; }

    public DateTime? LastAliveSignal { get; set; }
}
