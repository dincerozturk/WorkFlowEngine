using WorkFlowManager.Common.DataAccess._UnitOfWork;
using WorkFlowManager.Common.Tables;

namespace WorkFlowManager.Services.DbServices
{
    public interface IDocumentService
    {
        void Add(Document document);

        void Remove(Document document);
    }
}
