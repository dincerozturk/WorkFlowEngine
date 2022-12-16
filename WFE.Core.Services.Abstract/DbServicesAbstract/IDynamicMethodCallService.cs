using System;
using System.Configuration;
using System.Linq;
using System.Reflection;
using WorkFlowManager.Common.DataAccess._UnitOfWork;

namespace WorkFlowManager.Services.DbServices
{

    public interface IDynamicMethodCallService
    {
        string Caller(IUnitOfWork unitOfWork, string methodCallString, IWorkFlowDataService workFlowDataService);
    }
}
