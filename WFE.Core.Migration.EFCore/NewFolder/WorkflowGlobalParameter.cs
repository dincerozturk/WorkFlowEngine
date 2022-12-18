using System;
using System.Collections.Generic;

namespace WFE.Core.Migration.EFCore.Models;

public partial class WorkflowGlobalParameter
{
    public Guid Id { get; set; }

    public string Type { get; set; }

    public string Name { get; set; }

    public string Value { get; set; }
}
