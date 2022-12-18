using System;
using System.Collections.Generic;

namespace WFE.Core.Migration.EFCore.Models;

public partial class WorkflowApprovalHistory
{
    public Guid Id { get; set; }

    public Guid ProcessId { get; set; }

    public string IdentityId { get; set; }

    public string AllowedTo { get; set; }

    public DateTime? TransitionTime { get; set; }

    public long? Sort { get; set; }

    public string InitialState { get; set; }

    public string DestinationState { get; set; }

    public string TriggerName { get; set; }

    public string Commentary { get; set; }
}
