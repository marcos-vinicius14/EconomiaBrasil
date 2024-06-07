using System.Text.Json.Serialization;
using EconomiaBrasil.Models;

namespace EconomiaBrasil.Responses;

public class ReuniaoResponse<TData>
{
    [JsonConstructor]
    public ReuniaoResponse()
        => _statusCode = Configuration.DefaultStatusCode;

    public ReuniaoResponse(
        TData? data,
        int statusCode = 200,
        string message = null)
    {
        Data = data;
        _statusCode = statusCode;
        Message = message;
    }
    private int _statusCode = Configuration.DefaultStatusCode;
    public TData? Data { get; set; }
    public string? Message { get; set; }
    public bool IsSucess => _statusCode is >= 200 and <= 299;
}