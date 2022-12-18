using System;
using System.Collections.Generic;

namespace WFE.Core.Migration.EFCore.Models;

public partial class BusinessProcess
{
    public int Id { get; set; }

    public int? OwnerId { get; set; }

    public string Name { get; set; }

    public int? OwnerSubProcessTraceId { get; set; }

    public int? RelatedTaskId { get; set; }

    public virtual BaseTable IdNavigation { get; set; }

    public virtual ICollection<BusinessProcess> InverseOwner { get; } = new List<BusinessProcess>();

    public virtual BusinessProcess Owner { get; set; }

    public virtual WorkFlowTrace OwnerSubProcessTrace { get; set; }

    public virtual Task RelatedTask { get; set; }
}
