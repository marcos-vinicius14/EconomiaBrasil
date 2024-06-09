using System.Text.Json;
using EconomiaBrasil.Models;
using EconomiaBrasil.Responses;

namespace EconomiaBrasil.Handlers;

public class GetInformationSelicHandler : IGetInformationSelic
{
    private readonly IHttpClientFactory _httpClientFactory;

    public GetInformationSelicHandler(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<Response<ReuniaoModel>> GetLastAta(int numberOfAtas = 1)
    {
        var client = _httpClientFactory.CreateClient("ListATAS");
        Console.WriteLine(Configuration.ListAtasUrl);
        using (var response = await client.GetAsync(Configuration.ListAtasUrl))
        {
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStreamAsync();
                var listAtas = await JsonSerializer.DeserializeAsync<Response<ReuniaoModel>>(result);

                return listAtas
                       ?? new Response<ReuniaoModel>(null, 404, "Não foi possível encontrar uma reunião.");
            }
            else
            {
                return new Response<ReuniaoModel>(null, 500, "Erro ao realizar a requisição.");
            }
        }
    }

    public async Task<Response<ComunicadoModel>> GetLatestAnnouncement()
    {
        var client = _httpClientFactory.CreateClient("DetailsSelic");
        var numberOfLastAta = await GetLastAta();

        if (numberOfLastAta.Data is null)
            return new Response<ComunicadoModel>(null, 404, "Não foi possível encontrar a ATA da reunião");

        using (var response = await client.GetAsync(Configuration.DetailsSelicUrl + numberOfLastAta.Data.nroReuniao))
        {
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStreamAsync();
                var lastAnnouncement = await JsonSerializer.DeserializeAsync<Response<ComunicadoModel>>(result);

                return lastAnnouncement
                       ?? new Response<ComunicadoModel>(null, 404, "Não foi possível encontrar o último comunicado.");
            }
            else
            {
                return new Response<ComunicadoModel>(null, 404, "Não foi possível encontrar uma reunião.");
            }
        }
    }
}