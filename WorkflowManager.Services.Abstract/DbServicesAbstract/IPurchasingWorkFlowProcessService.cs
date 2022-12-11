using AutoMapper;
//using Hangfire;
//using System.Web.Mvc;
using WorkFlowManager.Common.DataAccess._UnitOfWork;
using WorkFlowManager.Common.Tables;
using WorkFlowManager.Common.ViewModels;

namespace WorkFlowManager.Services.DbServices
{
    public interface IPurchasingWorkFlowProcessService : IWorkFlowProcessService, IWorkFlow
    {
        #region Decission Methods




        #endregion

        #region Workflow

        //bool FormValidate(WorkFlowFormViewModel formData, ModelStateDictionary modelState);


        //void FormSave(WorkFlowFormViewModel formData);

        //void WorkFlowFormSave<TClass, TVM>(WorkFlowFormViewModel workFlowFormViewModel);

        //void WorkFlowProcessCancel(int workFlowTraceId);

        // void CancelWorkFlowTrace(int workFlowTraceId, int targetProcessId);

        //void GoToWorkFlowNextProcess(int ownerId);

        //string DecisionPointJobCall(string id, string jobId, string hourInterval);
        #endregion

    }
}
