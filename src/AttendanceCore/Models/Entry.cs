using System;
using System.ComponentModel.DataAnnotations;
using AttendanceCore.Infrastructure;

namespace AttendanceCore.Models
{
    public class Entry
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public EntryType Type { get; set; }

        [Required]
        public DateTimeOffset Time { get; set; } = DateTimeOffset.Now;

        [Required]
        public Guid PersonId { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 20)]
        public string Note { get; set; }
    }
}