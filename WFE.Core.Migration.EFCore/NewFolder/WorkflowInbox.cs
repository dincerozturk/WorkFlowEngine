using System;
using System.Collections.Generic;

namespace WFE.Core.Migration.EFCore.Models;

public partial class WorkflowInbox
{
    public Guid Id { get; set; }

    public Guid ProcessId { get; set; }

    public string IdentityId { get; set; }

    public DateTime AddingDate { get; set; }

    public string AvailableCommands { get; set; }
}
