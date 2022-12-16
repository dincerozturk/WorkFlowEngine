using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using WorkFlowManager.Common.DataAccess._UnitOfWork;
using WorkFlowManager.Common.Tables;
using WorkFlowManager.Common.ViewModels;

namespace WorkFlowManager.Services.DbServices
{
    public interface IFormService : IDisposable
    {
        //private IList<FormViewViewModel> GetAll(int taskId = 0);


        IEnumerable<FormViewViewModel> Read(int taskId);

        void Create(FormViewViewModel formView);


        void Update(FormViewViewModel formView);

        void Destroy(FormViewViewModel formView);

    }
}
