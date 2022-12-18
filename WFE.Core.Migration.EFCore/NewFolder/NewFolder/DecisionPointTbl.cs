using System;
using System.Collections.Generic;

namespace WFE.Core.Migration.EFCore.Models;

public partial class DecisionPoint
{
    public int Id { get; set; }

    public int DecisionMethodId { get; set; }

    public int RepetitionFrequenceByHour { get; set; }

    public int? CancelProcessId { get; set; }

    public string CancelProcessText { get; set; }

    public virtual Process CancelProcess { get; set; }

    public virtual DecisionMethod DecisionMethod { get; set; }

    public virtual Condition IdNavigation { get; set; }
}
