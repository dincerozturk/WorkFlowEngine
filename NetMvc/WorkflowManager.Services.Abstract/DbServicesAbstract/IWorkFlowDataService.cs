using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using WorkFlowManager.Common.DataAccess._UnitOfWork;
using WorkFlowManager.Common.Tables;
using WorkFlowManager.Common.ViewModels;

namespace WorkFlowManager.Services.DbServices
{

    public interface IWorkFlowDataService
    {
        IEnumerable<ProcessVM> GetWorkFlowProcessList(int taskId);

        IEnumerable<UserProcessViewModel> GetWorkFlowTraceList();

        UserProcessViewModel GetWorkFlowTrace(int workFlowTraceId);

        //private List<int> GetWorkFlowTraceIdList();

    }
}
