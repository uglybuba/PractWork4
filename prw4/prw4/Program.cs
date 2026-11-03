using prw4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace prw4
{
    public enum NotificationType
{
    Info,
    Warning,
    Error,
    System
}

public enum SortNotificationBy
{
    Date,
    Priority,
    Title
}

    public class Notification
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Content { get; set; }
    public NotificationType Type { get; set; } // Info, Warning, Error, System
    public DateTime CreatedAt { get; set; }
    public int Priority { get; set; } // 0 (низкий) до 5 (высокий)
    public bool IsRead { get; set; }
}

public class NotificationFilterOptions
{
    public bool? IsRead { get; set; }
    public NotificationType[]? Types { get; set; } // список нужных типов
    public string? SearchText { get; set; }
    public int? MinPriority { get; set; }
    public SortNotificationBy? SortBy { get; set; } // по Date, Priority, Title
    public bool Descending { get; set; }
}

public static class NotificationExtensions
{
    public static IEnumerable<Notification> FilterAndSort(
      IEnumerable<Notification> notifications,
      NotificationFilterOptions options
  )
    {
        var result = notifications.AsQueryable();

        if (options.IsRead.HasValue)
            result = result.Where(n => n.IsRead == options.IsRead.Value);

        if (options.Types != null)
            result = result.Where(n => options.Types.Contains(n.Type));

        if (!string.IsNullOrEmpty(options.SearchText))
            result = result.Where(n => n.Title.Contains(options.SearchText));

        if (options.MinPriority.HasValue)
            result = result.Where(n => n.Priority >= options.MinPriority.Value);

        if (options.SortBy == SortNotificationBy.Date)
            result = options.Descending ? result.OrderByDescending(n => n.CreatedAt) : result.OrderBy(n => n.CreatedAt);
        else if (options.SortBy == SortNotificationBy.Priority)
            result = options.Descending ? result.OrderByDescending(n => n.Priority) : result.OrderBy(n => n.Priority);
        else if (options.SortBy == SortNotificationBy.Title)
            result = options.Descending ? result.OrderByDescending(n => n.Title) : result.OrderBy(n => n.Title);

        return result.ToList();
    }
} }

internal class Program
{
    static void Main()
    {
        var list = new List<Notification>
        {
            new Notification {IDictionary = 1, AssemblyTitleAttribute = "test", Priority = 5, IsRead = false}
        };

        var res = NotificationExtensions
    }
}
