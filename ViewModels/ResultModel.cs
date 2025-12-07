public class ResultModel
{
    public bool Status { get; set; }
    public string Message { get; set; }
    public object Data { get; set; }

    public static ResultModel Success(string message, object data = null)
    {
        return new ResultModel
        {
            Status = true,
            Message = message,
            Data = data
        };
    }

    public static ResultModel Error(string message)
    {
        return new ResultModel
        {
            Status = false,
            Message = message
        };
    }
}
