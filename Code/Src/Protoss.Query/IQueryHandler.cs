using System.Threading.Tasks;

namespace Protoss.Query
{
    public interface IQueryHandler<in TRequest, TResponse> where TRequest : IQuery
    {
        Task<TResponse> Handle(TRequest request);
    }
}