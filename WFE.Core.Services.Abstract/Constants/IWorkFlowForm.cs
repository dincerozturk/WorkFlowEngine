//using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WorkFlowManager.Common.ViewModels;

namespace WorkFlowManager.Common.Constants
{
    public interface IWorkFlowForm
    {
        void Save(WorkFlowFormViewModel formData);
        bool Validate(WorkFlowFormViewModel formData, ModelStateDictionary modelState);
        WorkFlowFormViewModel Load(WorkFlowFormViewModel workFlowFormViewModel);
    }
}
