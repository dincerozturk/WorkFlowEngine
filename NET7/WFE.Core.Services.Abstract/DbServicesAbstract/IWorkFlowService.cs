using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using WorkFlowManager.Common.Constants;
using WorkFlowManager.Common.DataAccess._UnitOfWork;
using WorkFlowManager.Common.Enums;
using WorkFlowManager.Common.Factory;
using WorkFlowManager.Common.Tables;
using WorkFlowManager.Common.ViewModels;

namespace WorkFlowManager.Services.DbServices
{
    public interface IWorkFlowService
    {
        IEnumerable<WorkFlow> GetWorkFlowList();

        IEnumerable<WorkFlowManager.Common.Tables.Task> GetTaskList();

        IEnumerable<Process> GetProcessList(int gorevId);


        string GetWorkFlowDiagram(int gorevId);

        void SetWorkFlowDiagram(int taskId);

        string Delete(int processId);
        int AddOrUpdate<T>(T process) where T : Process;



        //private Process GetBefore(int processId);


        void SetNextByProcessCode(string processCode, int? nextProcessId);

        IEnumerable<DecisionMethod> GetDecisionMethodList(int taskId);

        IEnumerable<FormView> GetFormViewList(int taskId);

        SummaryOfWorkFlowViewModel GetWorkFlowSummary(int taskId);

        int CreateNewTask(WorkFlow testWorkFlow);

        WorkFlow GetTestWorkFlow();

        IEnumerable<Process> GetMainProcessList(int gorevId);


        Process GetProcess(int processId);

        Process GetProcess(string processCode);


        //private IEnumerable<Process> ProcessListWhichBeforeIsNull(int gorevId);

        //private void SetStartingProcess(int taskId);

        void AddOrUpdate(ProcessForm formData);
    }
}