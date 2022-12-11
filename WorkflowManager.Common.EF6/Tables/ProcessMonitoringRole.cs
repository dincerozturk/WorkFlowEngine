﻿using WorkFlowManager.Common.Enums;

namespace WorkFlowManager.Common.Tables
{
    public class ProcessMonitoringRole
    {
        public int ProcessId { get; set; }
        public virtual Process Process { get; set; }
        public virtual ProjectRole ProjectRole { get; set; }
    }
}
