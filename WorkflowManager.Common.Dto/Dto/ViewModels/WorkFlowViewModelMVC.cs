//using FluentValidation.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
//using System.Web.Mvc;
//using WorkflowManager.Common.Dto.Dto;
using WorkFlowManager.Common.Enums;
using WorkFlowManager.Common.Tables;
//using WorkFlowManager.Common.Validation;

namespace WorkFlowManager.Common.ViewModels
{
    //[Validator(typeof(ProcessFormValidator))]
    public class ProcessForm
    {
        public int? ConditionId { get; set; }
        public string ConditionName { get; set; }
        public ProcessType ProcessType { get; set; }
        public int Id { get; set; }

        [Display(Name = "Assigned Role")]
        public ProjectRole AssignedRole { get; set; }

        [Display(Name = "Special Form Type")]
        public int? FormViewId { get; set; }

        public IEnumerable<FormView> FormViewList { get; set; }
        //public CustomSelectList FormViewList { get; set; }
        //MonitoringRoleList
        public IEnumerable<MonitoringRoleCheckbox> MonitoringRoleCheckboxes { get; set; }

        public string ProcessUniqueCode { get; set; }
        public int TaskId { get; set; }
        public Task Task { get; set; }

        [Display(Name = "Next Process")]
        public int? NextProcessId { get; set; }
        public IEnumerable<Process> MainProcessList { get; set; }
        //public CustomSelectList MainProcessList { get; set; }

        [Display(Name = "Next Button Caption")]
        public string NextText { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }


        [Display(Name = "Analysis Information")]
        [DataType(DataType.MultilineText)]
        public string SpecialFormAnalysis { get; set; }



        [Display(Name = "Message For Monitor")]
        public string MessageForMonitor { get; set; }


        [Display(Name = "Is Description Mandatory")]
        public bool IsDescriptionMandatory { get; set; }
        [Display(Name = "Is FileUpload Mandatory")]
        public bool IsStandardForm { get; set; }

        [Display(Name = "Select Decision Method")]
        public int? DecisionMethodId { get; set; }
        public IEnumerable<DecisionMethod> DecisionMethodList { get; set; }
        //public CustomSelectList DecisionMethodList { get; set; }

        [UIHint("_FileUploadTemplate")]
        public FileUpload TemplateFileList { get; set; }

        [UIHint("_FileUploadTemplate")]
        public FileUpload AnalysisFileList { get; set; }




        public IEnumerable<int> RepetitionHourList { get; set; }
        //public CustomSelectList RepetitionHourList { get; set; }

        [Display(Name = "Repetition Frequence By Hour")]
        public int? RepetitionFrequenceByHour { get; set; }

        [StringLength(200)]
        public string Value { get; set; }

        [Display(Name = "Variable Name")]
        public string VariableName { get; set; }

        [Display(Name = "TaskId,VariableName List JSON")]
        public string TaskVariableList { get; set; }
    }

    public class NextProcess
    {
        public IEnumerable<Process> MainProcessList { get; set; }
        //public CustomSelectList MainProcessList { get; set; }
        public Process Process { get; set; }
    }

    public class WorkFlowViewModel
    {
        public int ActiveTaskId { get; set; }
        public int FirstProcessId { get; set; }
        public IEnumerable<NextProcess> NextProcessList { get; set; }
    }

}
