namespace HowClient.Components;

public interface IErrorComponent
{
    void ShowError(string title, string message);
    void RemoveErrorItem(long errorId);
}