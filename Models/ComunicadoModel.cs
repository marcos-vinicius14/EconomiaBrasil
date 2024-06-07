
namespace EconomiaBrasil.Models;

public class ComunicadoModel
{
    public int nro_reuniao { get; set; }
    public string Titulo { get; set; } = String.Empty;
    public string TextoComunicado { get; set; } = String.Empty;
    public DateTime DataReferencia { get; set; }
}