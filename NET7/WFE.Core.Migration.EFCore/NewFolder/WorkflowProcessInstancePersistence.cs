using System;
using System.Collections.Generic;

namespace WFE.Core.Migration.EFCore.Models;

public partial class WorkflowProcessInstancePersistence
{
    public Guid Id { get; set; }

    public Guid ProcessId { get; set; }

    public string ParameterName { get; set; }

    public string Value { get; set; }
}
