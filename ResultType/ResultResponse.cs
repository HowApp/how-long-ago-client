namespace HowClient.ResultType;

public class ResultResponse
{
    public bool Succeeded { get; set; }
    public bool Failed { get; set; }
    public int Code { get; }
    public Dictionary<string, string> Error { get; set; }
}

public class ResultResponse<TData> : ResultResponse
{
    public TData? Data { get; set; }
}