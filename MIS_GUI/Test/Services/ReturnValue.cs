namespace IS.Services;

public class ReturnValue
{
    public ReturnValue(bool status, string? message, object? data)
    {
        Status = status;
        Message = message;
        Data = data;
    }

    /// <summary>
    ///     返回错误信息
    /// </summary>
    /// <param name="message"></param>
    public ReturnValue(string message)
    {
        Message = message;
        Status = false;
        Data = null;
    }

    /// <summary>
    ///     返回成功信息
    /// </summary>
    /// <param name="status"></param>
    /// <param name="data"></param>
    public ReturnValue(bool status, object data)
    {
        Status = true;
        Message = null;
        Data = data;
    }

    public bool Status { get; set; } // 函数是否执行成功
    public string? Message { get; set; } // 如果执行失败的错误信息
    public object? Data { get; set; } // 执行成功后的返回值，如果有的话

    public override string ToString()
    {
        var s = Status ? "执行成功" : "执行失败";
        var s1 = Message == null ? "" : $"{Message}";
        var s2 = Data == null ? "" : $"{Data}";
        return $"执行状态 : {s}\n" +
               $"执行信息 : {s1}\n" +
               $"执行结果 : {s2}\n";
    }
}