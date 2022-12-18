using System;
using System.Collections.Generic;

namespace WFE.Core.Migration.EFCore.Models;

public partial class WorkflowProcessTimer
{
    public Guid Id { get; set; }

    public Guid ProcessId { get; set; }

    public Guid RootProcessId { get; set; }

    public string Name { get; set; }

    public DateTime NextExecutionDateTime { get; set; }

    public bool Ignore { get; set; }
}
