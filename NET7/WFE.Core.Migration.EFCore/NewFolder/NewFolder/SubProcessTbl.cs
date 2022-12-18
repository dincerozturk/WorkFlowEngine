using System;
using System.Collections.Generic;

namespace WFE.Core.Migration.EFCore.Models;

public partial class SubProcess
{
    public int Id { get; set; }

    public string TaskVariableList { get; set; }

    public virtual Process IdNavigation { get; set; }
}
