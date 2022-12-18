using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlowManager.Common.Enums;
using WorkFlowManager.Common.Tables;
using WorkFlowManager.Common.ViewModels;

namespace WorkflowManager.Common.Dto
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Process, ProcessVM>()
                    .ForMember(a => a.IsCondition, opt => opt.MapFrom(c => (c.GetType() == typeof(Condition) || c.GetType() == typeof(DecisionPoint))))
                    .ForMember(a => a.ConditionId, opt => opt.MapFrom(c => (c as ConditionOption).ConditionId));


            CreateMap<WorkFlowTrace, WorkFlowTrace>()
            .ForMember(dest => dest.ConditionOption, opt => opt.Ignore())
            .ForMember(dest => dest.Process, opt => opt.Ignore())
            .ForMember(dest => dest.Owner, opt => opt.Ignore());

            CreateMap<WorkFlowFormViewModel, WorkFlowTrace>();
            CreateMap<WorkFlowTrace, WorkFlowFormViewModel>();

            CreateMap<ProcessForm, Process>()
                .ConstructUsing(x => new Process())
                .Include<ProcessForm, Condition>()
                .Include<ProcessForm, SubProcess>()
                .Include<ProcessForm, ConditionOption>()
                .Include<ProcessForm, DecisionPoint>()
                .ForMember(a => a.ProcessMonitoringRoles,
                    opt => opt.MapFrom(c => c.MonitoringRoleCheckboxes.Where(x => x.IsChecked == true).Select(t => new ProcessMonitoringRole
                    {
                        ProcessId = c.Id,
                        ProjectRole = (int)t.ProjectRole
                    })));

            CreateMap<ProcessForm, Condition>()
                .ConstructUsing(x => new Condition());
            CreateMap<ProcessForm, ConditionOption>()
                .ConstructUsing(x => new ConditionOption());
            CreateMap<ProcessForm, DecisionPoint>()
                .ConstructUsing(x => new DecisionPoint());
            CreateMap<ProcessForm, SubProcess>()
                .ConstructUsing(x => new SubProcess());

            CreateMap<DecisionMethodViewModel, DecisionMethod>();
            CreateMap<FormViewViewModel, FormView>();
            CreateMap<Process, Process>();
            CreateMap<Condition, Condition>();
            CreateMap<ConditionOption, ConditionOption>();
            CreateMap<DecisionPoint, DecisionPoint>();

            CreateMap<ProcessMonitoringRole, MonitoringRoleCheckbox>()
                .ForMember(a => a.IsChecked, opt => opt.MapFrom(c => true));

            CreateMap<Process, ProcessForm>()
                .ForMember(a => a.ConditionId, opt => opt.MapFrom(c => (c as ConditionOption).ConditionId))
                .ForMember(a => a.ConditionName, opt => opt.MapFrom(c => (c as ConditionOption).Condition.Name))
                .ForMember(a => a.ProcessType, opt => opt.MapFrom(c => ProcessType.Process))
                .ForMember(a => a.Value, opt => opt.MapFrom(c => (c as ConditionOption).Value));

            CreateMap<Condition, ProcessForm>()
                .ForMember(a => a.ProcessType, opt => opt.MapFrom(c => ProcessType.Condition));

            CreateMap<SubProcess, ProcessForm>()
                .ForMember(a => a.ProcessType, opt => opt.MapFrom(c => ProcessType.SubProcess));

            CreateMap<DecisionPoint, ProcessForm>()
                .ForMember(a => a.ProcessType, opt => opt.MapFrom(c => ProcessType.DecisionPoint))
                .ForMember(a => a.DecisionMethodId, opt => opt.MapFrom(c => c.DecisionMethodId))
                .ForMember(a => a.RepetitionFrequenceByHour, opt => opt.MapFrom(c => c.RepetitionFrequenceByHour));

            CreateMap<ConditionOption, ProcessForm>()
                .ForMember(a => a.ProcessType, opt => opt.MapFrom(c => ProcessType.OptionList));

            CreateMap<TestForm, TestWorkFlowFormViewModel>();
            CreateMap<TestWorkFlowFormViewModel, TestForm>();

            CreateMap<WorkFlowFormViewModel, TestWorkFlowFormViewModel>();
            CreateMap<WorkFlowFormViewModel, SubBusinessProcessViewModel>();
        }
    }
}
