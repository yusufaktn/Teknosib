public class ResponseDto<T>
{
    public T Data { get; set; }
    public string Message { get; set; }
    public bool IsSuccess { get; set; }
    public int StatusCode { get; set; }
    public List<string> Errors { get; set; }

    public static ResponseDto<T> Success(T data, int statusCode, string message = "")
    {
        return new ResponseDto<T> { Data = data, StatusCode = statusCode, IsSuccess = true, Message = message };
    }

    public static ResponseDto<T> Fail(List<string> errors, int statusCode)
    {
        return new ResponseDto<T> { Errors = errors, StatusCode = statusCode, IsSuccess = false };
    }

    public static ResponseDto<T> Fail(string error, int statusCode)
    {
        return new ResponseDto<T> { Errors = new List<string> { error }, StatusCode = statusCode, IsSuccess = false };
    }
}
