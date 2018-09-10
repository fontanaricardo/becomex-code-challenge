using System.Threading.Tasks;

namespace RoboCore.Business
{
    public interface IRequestHandler<TRequest, TResponse>
    {
         TResponse Handle(TRequest request);
    }
}