using System.ComponentModel.DataAnnotations;

namespace AttendanceCore.ViewModels.Home
{
    public class EntryViewModel
    {
        public int EntryType { get; set; }

        [StringLength(1000, MinimumLength = 10)]
        [DataType(DataType.MultilineText)]
        public string Note { get; set; }
    }
}