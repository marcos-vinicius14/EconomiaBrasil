namespace EconomiaBrasil.Requests;

public class StatementRequest
{
    public string Title { get; set; } = String.Empty;
    public DateTime ReferenceDate { get; set; }
    public string Content { get; set; } = String.Empty;
}