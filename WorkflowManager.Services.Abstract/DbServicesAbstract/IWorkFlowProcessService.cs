using AutoMapper;
//using Hangfire;
//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using WorkFlowManager.Common.Constants;
using WorkFlowManager.Common.DataAccess._UnitOfWork;
using WorkFlowManager.Common.Dto;
using WorkFlowManager.Common.Enums;
using WorkFlowManager.Common.Tables;
//using WorkFlowManager.Common.Validation;
using WorkFlowManager.Common.ViewModels;
//using WorkFlowManager.Helper;

namespace WorkFlowManager.Services.DbServices
{
    public interface IWorkFlowProcessService
    {

        int GetOwnerIdFromId(int id);

        int GetLastProcessId(int ownerId);

        int StartWorkFlow(int ownerId, Task task);

        int StartWorkFlow(int ownerId, string taskName);

        int StartWorkFlow(int ownerId, int taskId);


        void AddOrUpdate(WorkFlowTrace workFlowTrace);

        string DecisionPointJobCallBase(string id, string jobId, string hourInterval);

        string GetWorkFlow(string gorevAkis, int WorkFlowTraceId);

        IEnumerable<UserProcessViewModel> WorkFlowTraceList(int ownerId);

        List<WorkFlowTraceVM> ProgressProcessList(int workFlowTraceId);

        List<UserProcessViewModel> TargetProcessListForCancel(int WorkFlowTraceId);

        bool SearchProcessInsideNextPath(List<int> elementOfTree, IEnumerable<ProcessVM> gorevWorkFlowTraceListesi, int gorevWorkFlowTraceId, int kontrolEdilecekGorevWorkFlowTraceId);

        WorkFlowTrace WorkFlowTraceDetail(int workFlowTraceId);

        void WorkFlowFormSave<TClass, TVM>(WorkFlowFormViewModel workFlowFormViewModel) 
            where TClass : class
            where TVM : WorkFlowFormViewModel;


        WorkFlowFormViewModel WorkFlowFormLoad(WorkFlowFormViewModel workFlowFormViewModel);

        //private IWorkFlowForm GetWorkFlowForm(string formViewName);

        void CustomFormSave(WorkFlowFormViewModel formData);


        bool CustomFormValidate(WorkFlowFormViewModel formData, ModelStateDictionary modelState);


        UserProcessViewModel GetUserProcessVM(int workFlowTraceId);

        void WorkFlowProcessCancel(int workFlowTraceId);


        void CancelWorkFlowTrace(int workFlowTraceId, int targetProcessId);


        string GetVariable(string key, int ownerId);
        void SetVariable(string key, string value, int ownerId);

        void GoToWorkFlowNextProcess(int ownerId);

        //private void CreateWorkFlowTrace(int targetProcessId, int ownerId);


        //private void CreateNewWorkFlowTrace(Process targetProcess, int ownerId);


        void DecisionPointTakeTheNextStep(int workFlowTraceId);

        bool StandartFormValidate(WorkFlowFormViewModel formData, ModelStateDictionary modelState);

        bool FullFormValidate(WorkFlowFormViewModel formData, ModelStateDictionary modelState);

        object SetNextProcessForWorkFlow(int WorkFlowTraceId);

        bool WorkFlowPermissionCheck(UserProcessViewModel userProcessVM);

        WorkFlowDTO WorkFlowBaseInfo(UserProcessViewModel kullaniciWorkFlowTraceVM);

        void SetWorkFlowTraceForm(WorkFlowFormViewModel workFlowFormVM, WorkFlowDTO workFlowBase);

    }
}
