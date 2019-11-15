using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace SignalRTest.SignalR
{
    public interface ITestHub
    {
        Task good(int count);
        Task bad(object obj);
    }

    public class TestHub : Hub<ITestHub>
    {

    }
}