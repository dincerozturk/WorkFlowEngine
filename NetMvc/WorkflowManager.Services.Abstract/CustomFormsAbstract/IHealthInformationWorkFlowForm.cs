using AutoMapper;
using System.Linq;
using System.Web.Mvc;
using WorkFlowManager.Common.Constants;
using WorkFlowManager.Common.DataAccess._UnitOfWork;
using WorkFlowManager.Common.Tables;
using WorkFlowManager.Common.ViewModels;
using WorkFlowManager.Services.DbServices;

namespace WorkFlowManager.Services.CustomForms
{
    public interface IHealthInformationWorkFlowForm : IWorkFlowForm
    {
        //void Save(WorkFlowFormViewModel formData);

        //bool Validate(WorkFlowFormViewModel formData, ModelStateDictionary modelState);

        //WorkFlowFormViewModel Load(WorkFlowFormViewModel workFlowFormViewModel);


    }
}
