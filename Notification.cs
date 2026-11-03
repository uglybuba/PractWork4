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

class Notification
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Content { get; set; }
    public NotificationType Type { get; set; } // Info, Warning, Error, System
    public DateTime CreatedAt { get; set; }
    public int Priority { get; set; } // 0 (низкий) до 5 (высокий)
    public bool IsRead { get; set; }
}

class NotificationFilterOptions
{
    public bool? IsRead { get; set; }
    public NotificationType[]? Types { get; set; } // список нужных типов
    public string? SearchText { get; set; }
    public int? MinPriority { get; set; }
    public SortNotificationBy? SortBy { get; set; } // по Date, Priority, Title
    public bool Descending { get; set; }
}
