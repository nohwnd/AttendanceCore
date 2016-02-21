using System;

namespace AttendanceCore.Services
{
    public interface ICurrentUser
    {
        Guid Id { get; }
    }
}