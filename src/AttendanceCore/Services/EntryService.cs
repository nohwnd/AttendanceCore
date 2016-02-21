using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AttendanceCore.Infrastructure;
using AttendanceCore.Models;
using Microsoft.Data.Entity;

namespace AttendanceCore.Services
{
    public class EntryService : IEntryService
    {
        private readonly ApplicationDbContext _context;
        private readonly ICurrentUser _currentUser;


        public EntryService(ApplicationDbContext context, ICurrentUser currentUser)
        {
            _context = context;
            _currentUser = currentUser;
        }

        public Task AddEntryAsync(EntryViewModel vm)
        {
            var entry = new Entry
            {
                Type = (EntryType) vm.EntryType,
                PersonId = _currentUser.Id
            };
            _context.Entries.Add(entry);

            return _context.SaveChangesAsync();
        }

        public async Task<ICollection<EntryDisplayViewModel>> GetPageAsync(int i)
        {
            var page = 20;
            return await _context.Entries.OrderByDescending(e => e.Time)
                .Join(_context.Users,
                    entry => entry.PersonId.ToString(),
                    user => user.Id,
                    (entry, user) =>
                        new EntryDisplayViewModel {UserName = user.UserName, Time = entry.Time, Type = entry.Type})
                .Skip(i*page)
                .Take(page)
                .ToListAsync();
        }
    }

    public class EntryDisplayViewModel
    {
        public string UserName { get; set; }
        public EntryType Type { get; set; }
        public DateTimeOffset Time { get; set; }
    }
}