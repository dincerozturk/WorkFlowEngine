using System;
using System.Collections.Generic;

namespace WFE.Core.Migration.EFCore.Models;

public partial class WorkflowScheme
{
    public string Code { get; set; }

    public string Scheme { get; set; }

    public bool CanBeInlined { get; set; }

    public string InlinedSchemes { get; set; }

    public string Tags { get; set; }
}
