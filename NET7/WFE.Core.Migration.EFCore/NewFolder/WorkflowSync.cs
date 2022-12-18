using System;
using System.Collections.Generic;

namespace WFE.Core.Migration.EFCore.Models;

public partial class WorkflowSync
{
    public string Name { get; set; }

    public Guid Lock { get; set; }
}
