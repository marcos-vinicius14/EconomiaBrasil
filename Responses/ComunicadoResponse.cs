using EconomiaBrasil.Models;

namespace EconomiaBrasil.Responses;

public class ComunicadoResponse
{
    public List<ComunicadoModel> Conteudo { get; set; } = new();
}