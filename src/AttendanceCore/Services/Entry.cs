using System;
using System.ComponentModel.DataAnnotations;
using AttendanceCore.Infrastructure;

namespace AttendanceCore.Services
{
    public class Entry
    {
        [Key]
        public int Id { get; set; }

        public EntryType Type { get; set; }

        [Required]
        public DateTimeOffset Time { get; set; } = DateTimeOffset.Now;

        public Guid PersonId { get; set; }
    }
}