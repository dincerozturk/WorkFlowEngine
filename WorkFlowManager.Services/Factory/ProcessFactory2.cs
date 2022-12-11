using Newtonsoft.Json;
using System.Collections.Generic;
using WorkFlowManager.Common.Dto;
using WorkFlowManager.Common.Enums;
using WorkFlowManager.Common.Tables;

namespace WorkFlowManager.Common.Factory
{
    public class ProcessFactory2 : IProcessFactory
    {
        public Process CreateProcess(Task task, string name, ProjectRole assignedRole, string description = null, FormView formView = null)
        {
            return new Process(task, name, assignedRole, description, formView);
        }

        public SubProcess CreateSubProcess(Task task, string name, List<TaskVariable> taskVariableList)
        {
            return new SubProcess(task, name, JsonConvert.SerializeObject(taskVariableList));
        }


        public Condition CreateCondition(Task task, string name, ProjectRole assignedRole, string variableName = null, string description = null, FormView formView = null)
        {
            return new Condition(task, name, assignedRole, variableName, description, formView);
        }
        public DecisionPoint CreateDecisionPoint(Task task, string name, DecisionMethod decisionMethod, string variableName = null, int repetitionFrequenceByHour = 1, string description = null, FormView formView = null)
        {
            return new DecisionPoint(task, name, decisionMethod, variableName, repetitionFrequenceByHour, description, formView);
        }


        public ConditionOption CreateConditionOption(string name, ProjectRole assignedRole, Condition condition, string value = null)
        {
            return new ConditionOption(condition.Task, name, assignedRole, condition, value);
        }

        public ConditionOption CreateDecisionPointYesOption(string name, DecisionPoint decisionPoint)
        {
            return new ConditionOption(decisionPoint.Task, name, ProjectRole.System, decisionPoint, "Y");
        }
        public ConditionOption CreateDecisionPointNoOption(string name, DecisionPoint decisionPoint)
        {
            return new ConditionOption(decisionPoint.Task, name, ProjectRole.System, decisionPoint, "N");
        }
    }
}
