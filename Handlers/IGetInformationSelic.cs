using EconomiaBrasil.Requests;

namespace EconomiaBrasil.Handlers;

public interface IGetInformationSelic
{
    Task<IEnumerable<ListAtasModels>> GetInformationSelic(int numberOfAtas = 1);
    Task<ComunicadoModel> DetailsSelic();
}