//using Newtonsoft.Json;
using System.Collections.Generic;
using WorkFlowManager.Common.Dto;
using WorkFlowManager.Common.Enums;
using WorkFlowManager.Common.Tables;

namespace WorkFlowManager.Common.Factory
{
    public interface IProcessFactory
    {
        Process CreateProcess(Task task, string name, ProjectRole assignedRole, string description = null, FormView formView = null);

        SubProcess CreateSubProcess(Task task, string name, List<TaskVariable> taskVariableList);


        Condition CreateCondition(Task task, string name, ProjectRole assignedRole, string variableName = null, string description = null, FormView formView = null);
        DecisionPoint CreateDecisionPoint(Task task, string name, DecisionMethod decisionMethod, string variableName = null, int repetitionFrequenceByHour = 1, string description = null, FormView formView = null);


        ConditionOption CreateConditionOption(string name, ProjectRole assignedRole, Condition condition, string value = null);

        ConditionOption CreateDecisionPointYesOption(string name, DecisionPoint decisionPoint);
        ConditionOption CreateDecisionPointNoOption(string name, DecisionPoint decisionPoint);
    }
}
