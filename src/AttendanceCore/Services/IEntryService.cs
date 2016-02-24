using System.Collections.Generic;
using System.Threading.Tasks;
using AttendanceCore.ViewModels.Home;

namespace AttendanceCore.Services
{
    public interface IEntryService
    {
        Task AddEntryAsync(EntryViewModel vm);
        Task<ICollection<EntryDisplayViewModel>> GetPageAsync(int i);
    }
}