using AutoMapper;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;
//using System.Web.Mvc;
using WorkFlowManager.Common.Constants;
using WorkFlowManager.Common.DataAccess._UnitOfWork;
using WorkFlowManager.Common.Tables;
using WorkFlowManager.Common.ViewModels;
using WorkFlowManager.Services.DbServices;

namespace WorkFlowManager.Services.CustomForms
{
    public class HealthInformationWorkFlowForm : IHealthInformationWorkFlowForm
    {
        private readonly ITestWorkFlowProcessService _testWorkFlowProcessService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public HealthInformationWorkFlowForm(IUnitOfWork unitOfWork, ITestWorkFlowProcessService testWorkFlowProcessService)
        {
            _unitOfWork = unitOfWork;
            _testWorkFlowProcessService = testWorkFlowProcessService;
        }

        public void Save(WorkFlowFormViewModel formData)
        {
        }

        public bool Validate(WorkFlowFormViewModel formData, ModelStateDictionary modelState)
        {
            return true;
        }

        public WorkFlowFormViewModel Load(WorkFlowFormViewModel workFlowFormViewModel)
        {

            var healthInformationFormList = _unitOfWork.Repository<BusinessProcess>().GetList(x => x.OwnerId == workFlowFormViewModel.OwnerId).ToList();

            if (healthInformationFormList.Count() == 0)
            {
                var physicalExamination = new BusinessProcess() { Name = "Physical Examination", OwnerId = workFlowFormViewModel.OwnerId };
                var psychotechniqueResult = new BusinessProcess() { Name = "Psychotechnique Result", OwnerId = workFlowFormViewModel.OwnerId };

                _unitOfWork.Repository<BusinessProcess>().Add(physicalExamination);
                _unitOfWork.Repository<BusinessProcess>().Add(psychotechniqueResult);
                _unitOfWork.Complete();
                healthInformationFormList.Add(physicalExamination);
                healthInformationFormList.Add(psychotechniqueResult);
            }
            SubBusinessProcessViewModel healthInformationForm = new SubBusinessProcessViewModel { SubBusinessProcessList = healthInformationFormList };

            _mapper.Map(workFlowFormViewModel, healthInformationForm);

            return healthInformationForm;
        }


    }
}
