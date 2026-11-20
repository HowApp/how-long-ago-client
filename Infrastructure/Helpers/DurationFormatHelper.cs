namespace HowClient.Infrastructure.Helpers;

public static class DurationFormatHelper
{
    public static TimeSpan CalculateElapsed(DateTime createdAtUtc)
    {
        var utcCreated = createdAtUtc.Kind switch
        {
            DateTimeKind.Local => createdAtUtc.ToUniversalTime(),
            DateTimeKind.Unspecified => DateTime.SpecifyKind(createdAtUtc, DateTimeKind.Utc),
            _ => createdAtUtc
        };

        var elapsed = DateTime.UtcNow - utcCreated;
        return elapsed < TimeSpan.Zero ? TimeSpan.Zero : elapsed;
    }

    public static string FormatLocalDateTime(DateTime createdAtUtc, string format = "MMM dd, yyyy HH:mm")
    {
        var utcCreated = createdAtUtc.Kind switch
        {
            DateTimeKind.Local => createdAtUtc.ToUniversalTime(),
            DateTimeKind.Unspecified => DateTime.SpecifyKind(createdAtUtc, DateTimeKind.Utc),
            _ => createdAtUtc
        };

        return utcCreated.ToLocalTime().ToString(format);
    }

    public static (int Days, int Hours, int Minutes, int Seconds) GetParts(TimeSpan duration)
    {
        if (duration < TimeSpan.Zero)
        {
            duration = TimeSpan.Zero;
        }

        return (duration.Days, duration.Hours, duration.Minutes, duration.Seconds);
    }

    public static string FormatHumanReadable(TimeSpan duration)
    {
        if (duration < TimeSpan.Zero)
        {
            duration = TimeSpan.Zero;
        }

        if (duration.TotalDays >= 365)
        {
            var years = (int)(duration.TotalDays / 365);
            var remainingDays = (int)(duration.TotalDays % 365);
            return $"{years}y {remainingDays}d {duration.Hours:D2}h {duration.Minutes:D2}m {duration.Seconds:D2}s";
        }

        if (duration.TotalDays >= 1)
        {
            return $"{duration.Days}d {duration.Hours:D2}h {duration.Minutes:D2}m {duration.Seconds:D2}s";
        }

        return $"{duration.Hours:D2}h {duration.Minutes:D2}m {duration.Seconds:D2}s";
    }
}
