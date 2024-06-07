
using EconomiaBrasil.Models;
using EconomiaBrasil.Responses;

namespace EconomiaBrasil.Handlers;

public class GetInformationSelicHandler : IGetInformationSelic
{
    public Task<List<Response<ReuniaoModel>>> GetAtas(int numberOfAtas = 1)
    {
        throw new NotImplementedException();
    }

    public Task<List<Response<ComunicadoModel>>> GetComunicados()
    {
        throw new NotImplementedException();
    }
}