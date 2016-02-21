using System;
using System.Security.Claims;
using Microsoft.AspNet.Http;

namespace AttendanceCore.Services
{
    public class CurrentUser : ICurrentUser
    {
        public CurrentUser(IHttpContextAccessor contextAccessor)
        {
            var id = contextAccessor.HttpContext.User.GetUserId();
            Id = string.IsNullOrWhiteSpace(id) ? Guid.Empty : Guid.Parse(id);
        }

        public Guid Id { get; }
    }
}