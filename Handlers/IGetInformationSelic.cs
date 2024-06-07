using EconomiaBrasil.Models;
using EconomiaBrasil.Responses;

namespace EconomiaBrasil.Handlers;

public interface IGetInformationSelic
{
    Task<Response<ReuniaoModel>> GetLastAta(int numberOfAtas = 1);
    Task<Response<ComunicadoModel>> GetLatestAnnouncement();
}