using System.Text.Json.Serialization;

namespace EconomiaBrasil.Requests;

public class ResponseModel<TData>
{
    [JsonConstructor]
    public ResponseModel()
        => _statusCode = Configuration.DefaultStatusCode;

    public ResponseModel(
        TData data,
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
    [JsonIgnore] public bool StatusCode => _statusCode is >= 200 and <= 299;
}