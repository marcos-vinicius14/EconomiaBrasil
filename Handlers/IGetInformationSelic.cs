using EconomiaBrasil.Models;
using EconomiaBrasil.Responses;

namespace EconomiaBrasil.Handlers;

public interface IGetInformationSelic
{
    Task<List<Response<ReuniaoModel>>> GetAtas(int numberOfAtas = 1);
    Task<List<Response<ComunicadoModel>>> GetComunicados();
}