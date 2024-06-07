using System.Text.Json.Serialization;

namespace EconomiaBrasil.Responses;

public class Response<TData>
{
    [JsonConstructor]
    public Response()
        => _statusCode = Configuration.DefaultStatusCode;

    public Response(
        TData? data,
        int statusCode = 200,
        string message = null)
    {
        Data = data;
        _statusCode = statusCode;
        Message = message;
    }
    private int _statusCode;
    public TData? Data { get; set; }
    public string? Message { get; set; }
    public bool IsSucess => _statusCode is >= 200 and <= 299;
}