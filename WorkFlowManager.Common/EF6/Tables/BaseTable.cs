using System;
using System.Collections.Generic;

namespace WorkFlowManager.Common.Tables
{
    public abstract class BaseTable
    {
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public DateTime? LastlyModifiedTime => UpdatedTime ?? CreatedTime;

        public virtual ICollection<Document> Documents { get; set; }
        public virtual ICollection<WorkFlowTrace> WorkFlowTraces { get; set; }
    }
}
