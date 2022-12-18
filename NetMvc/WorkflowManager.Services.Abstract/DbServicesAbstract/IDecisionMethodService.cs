using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using WorkFlowManager.Common.DataAccess._UnitOfWork;
using WorkFlowManager.Common.Tables;
using WorkFlowManager.Common.ViewModels;

namespace WorkFlowManager.Services.DbServices
{

    public interface IDecisionMethodService : IDisposable
    {
        IList<DecisionMethodViewModel> GetAll(int taskId = 0);

        IEnumerable<DecisionMethodViewModel> Read(int gorevId);

        void Create(DecisionMethodViewModel decisionMethod);


        void Update(DecisionMethodViewModel decisionMethod);

        void Destroy(DecisionMethodViewModel decisionMethod);

    }
}
