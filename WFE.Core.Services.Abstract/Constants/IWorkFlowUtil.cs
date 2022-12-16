using System.Collections.Generic;
using System.Linq;
using System.Text;
using WorkFlowManager.Common.DataAccess._UnitOfWork;
using WorkFlowManager.Common.Tables;

namespace WorkFlowManager.Common.Constants
{
    public interface IWorkFlowUtil
    {
        void SetWorkFlowDiagram(int taskId);
        void SetWorkFlowDiagram(IUnitOfWork _unitOfWork, int taskId);
    }
}
