using System.Threading.Tasks;

namespace AttendanceCore.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}