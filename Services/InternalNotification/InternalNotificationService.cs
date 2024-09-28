namespace HowClient.Services.InternalNotification;

public class InternalNotificationService
{
    // Event to notify subscribers when an error occurs
    public event Action<string> OnError;

    // Method to invoke the error notification
    public void NotifyError(string message)
    {
        OnError?.Invoke(message);
    }
}