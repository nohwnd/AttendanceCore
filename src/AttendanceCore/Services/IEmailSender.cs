using System.Threading.Tasks;

namespace AttendanceCore.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}