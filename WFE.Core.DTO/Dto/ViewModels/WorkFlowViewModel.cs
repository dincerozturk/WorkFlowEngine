//using FluentValidation.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
//using System.Web.Mvc;
using WorkFlowManager.Common.Enums;
using WorkFlowManager.Common.Tables;
//using WorkFlowManager.Common.Validation;

namespace WorkFlowManager.Common.ViewModels
{
    public class MonitoringRoleCheckbox
    {
        public ProjectRole ProjectRole { get; set; }
        public bool IsChecked { get; set; }
    }
    public class WorkFlowIndexViewModel
    {
        public string ActiveTaskName { get; set; }
        public int ActiveTaskId { get; set; }
        public IEnumerable<WorkFlowManager.Common.Tables.Task> TaskList { get; set; }
    }


    public class FormViewViewModel
    {
        public int Id { get; set; }
        public int TaskId { get; set; }

        [Required(ErrorMessage = "Form Tanımını Girmelisiniz.")]
        [Display(Name = "Name")]
        public string FormName { get; set; }


        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        public string FormDescription { get; set; }

        [UIHint("_ComplexityEnum")]
        [Display(Name = "Form Complexity Degree")]
        public FormComplexity FormComplexity { get; set; }

        [Range(1, 20, ErrorMessage = "{0} must be between {1} and  {2}.")]
        [Display(Name = "Number of Page")]
        public int NumberOfPage { get; set; }

        public string ViewName { get; set; }

        [Display(Name = "Completed")]
        public bool Completed { get; set; }
    }

    public class DecisionMethodViewModel
    {
        public int Id { get; set; }
        public int TaskId { get; set; }

        [Required(ErrorMessage = "Method name required.")]
        [Display(Name = "Name")]
        public string MethodName { get; set; }

        [Required(ErrorMessage = "Result of Method will be [Y]es/[N]o. Please describe input and algorithm.")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        public string MethodDescription { get; set; }


        [Display(Name = "Function Name")]
        public string MethodFunction { get; set; }

        [Display(Name = "Completed")]
        public bool Completed { get; set; }

    }

    public class SummaryOfWorkFlowViewModel
    {
        public int NumberOfCondition { get; set; }
        public int NumberOfDecisionPoint { get; set; }

        public int NumberOfProcessWhicHasSpecialForm { get; set; }
        public int NumberOfStandartProcess { get; set; }
        public int NumberOfTotalProcess { get; set; }


        public int NumberOfWillBeDesignedDecisionMethod { get; set; }

        public int NumberOfWillBeDesignedSimpleForm { get; set; }
        public int NumberOfWillBeDesignedSimplePage { get; set; }

        public int NumberOfWillBeDesignedMiddleForm { get; set; }
        public int NumberOfWillBeDesignedMiddlePage { get; set; }

        public int NumberOfWillBeDesignedComplexForm { get; set; }
        public int NumberOfWillBeDesignedComplexPage { get; set; }


        public int NumberOfTotalJobWillBeComplete { get; set; }

    }

    public class WorkFlowView
    {
        public string WorkFlowText { get; set; }
        public bool Flag { get; set; }
    }
}
