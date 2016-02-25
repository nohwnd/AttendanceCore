using System;
using AttendanceCore.Infrastructure;

namespace AttendanceCore.ViewModels.Home
{
    public class EntryDisplayViewModel
    {
        public string UserName { get; set; }
        public EntryType Type { get; set; }
        public DateTimeOffset Time { get; set; }

        public string Note { get; set; }
    }
}