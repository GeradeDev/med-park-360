using System.Threading.Tasks;
using MedPark.Common.Types;

namespace MedPark.Common.Handlers
{
    public interface IQueryHandler<TQuery,TResult> where TQuery : IQuery<TResult>
    {
        Task<TResult> HandleAsync(TQuery query);
    }
}