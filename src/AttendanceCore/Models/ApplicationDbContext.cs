using Microsoft.AspNet.Identity.EntityFramework;

namespace AttendanceCore.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
    }
}