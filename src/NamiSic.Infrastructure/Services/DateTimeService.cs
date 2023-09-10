using NamiSic.Application.Common.Interfaces;

namespace NamiSic.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
