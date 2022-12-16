using Microsoft.Win32;
using System;
using System.Collections.Generic;

namespace WorkFlowManager.Common.Tables
{
    public interface IBaseTable
    {
        int Id { get; set; }
        DateTime CreatedTime { get; set; }
        DateTime? UpdatedTime { get; set; }
        DateTime? LastlyModifiedTime { get; }

        ICollection<Document> Documents { get; set; }
        ICollection<WorkFlowTrace> WorkFlowTraces { get; set; }
    }


    public abstract class ABaseTable : IBaseTable
    {
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public DateTime? LastlyModifiedTime { get { return UpdatedTime ?? CreatedTime; } }

        public virtual ICollection<Document> Documents { get; set; }
        public virtual ICollection<WorkFlowTrace> WorkFlowTraces { get; set; }
    }

    public class BaseTable : ABaseTable
    {

    }
}
