using EconomiaBrasil.Models;

namespace EconomiaBrasil.Responses;

public class ReuniaoResponse
{
    public List<ReuniaoModel> Conteudo { get; set; } = new();
}