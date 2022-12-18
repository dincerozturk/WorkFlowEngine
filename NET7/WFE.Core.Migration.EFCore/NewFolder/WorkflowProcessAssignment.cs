using System;
using System.Collections.Generic;

namespace WFE.Core.Migration.EFCore.Models;

public partial class WorkflowProcessAssignment
{
    public Guid Id { get; set; }

    public string AssignmentCode { get; set; }

    public Guid ProcessId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string StatusState { get; set; }

    public DateTime DateCreation { get; set; }

    public DateTime? DateStart { get; set; }

    public DateTime? DateFinish { get; set; }

    public DateTime? DeadlineToStart { get; set; }

    public DateTime? DeadlineToComplete { get; set; }

    public string Executor { get; set; }

    public string Observers { get; set; }

    public string Tags { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }
}
