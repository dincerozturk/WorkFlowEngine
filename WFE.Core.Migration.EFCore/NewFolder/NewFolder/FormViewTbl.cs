using System;
using System.Collections.Generic;

namespace WFE.Core.Migration.EFCore.Models;

public partial class FormView
{
    public int Id { get; set; }

    public int TaskId { get; set; }

    public string FormName { get; set; }

    public string FormDescription { get; set; }

    public string ViewName { get; set; }

    public int FormComplexity { get; set; }

    public int NumberOfPage { get; set; }

    public bool Completed { get; set; }

    public virtual BaseTable IdNavigation { get; set; }

    public virtual ICollection<Process> Processs { get; } = new List<Process>();

    public virtual Task Task { get; set; }
}
