using EconomiaBrasil.Models;
using EconomiaBrasil.Responses;

namespace EconomiaBrasil.Handlers;

public interface IGetInformationSelic
{
    Task<List<ReuniaoModel>?> GetLastAta(int numberOfAtas = 1);
    Task<List<ComunicadoModel>> GetLatestAnnouncement();
}