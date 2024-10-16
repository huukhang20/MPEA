
namespace MPEA.Application.Model.RequestModel.NotificationRequest;

public class NotificationRequest
{
    public NotificationRequest(string title, string message, string userId)
    {
        Title = title;
        Message = message;
        UserId = userId;
    }

    public string Title { get; set; }
    public string Message { get; set; }
    public string? UserId { get; set; }
}