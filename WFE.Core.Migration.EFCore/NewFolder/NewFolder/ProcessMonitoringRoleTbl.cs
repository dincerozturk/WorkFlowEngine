using System;
using System.Collections.Generic;

namespace WFE.Core.Migration.EFCore.Models;

public partial class ProcessMonitoringRole
{
    public int ProcessId { get; set; }

    public int ProjectRole { get; set; }

    public virtual Process Process { get; set; }
}
