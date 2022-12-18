using System;
using System.Collections.Generic;

namespace WFE.Core.Migration.EFCore.Models;

public partial class WorkFlowEngineVariable
{
    public int Id { get; set; }

    public int OwnerId { get; set; }

    public string Key { get; set; }

    public string Value { get; set; }
}
