using System.Collections.Generic;
using WorkFlowManager.Common.Enums;

namespace WorkFlowManager.Web
{

    public interface IGlobal
    {

        //string GetUserName();

        List<ProjectRole> GetSystemRoles();

        List<ProjectRole> GetUnitRoles();

        List<ProjectRole> GetAllRoles();

    }
}