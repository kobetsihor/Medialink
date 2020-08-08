using Medialink.Dal.Models;

namespace Medialink.Dal.Abstractions
{
    public interface IOperationRepository
    {
        void Create(Operation operation);
    }
}