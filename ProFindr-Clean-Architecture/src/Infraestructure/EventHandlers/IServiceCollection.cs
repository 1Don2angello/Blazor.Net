
using System.Reflection;

namespace Infraestructure.EventHandlers
{
    public interface IServiceCollection
    {
        void AddMediatR(Action<object> value);
        void AddMediatR(Assembly assembly);
    }
}