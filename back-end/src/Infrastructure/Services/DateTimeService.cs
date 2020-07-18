using Assets.Application.Common.Interfaces;
using System;

namespace Assets.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
