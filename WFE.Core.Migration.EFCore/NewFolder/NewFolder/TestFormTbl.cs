using System;
using System.Collections.Generic;

namespace WFE.Core.Migration.EFCore.Models;

public partial class TestForm
{
    public int OwnerId { get; set; }

    public int Age { get; set; }

    public virtual BaseTable Owner { get; set; }
}
