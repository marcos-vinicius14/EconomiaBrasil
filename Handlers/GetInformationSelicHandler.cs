
using System.Text.Json;
using EconomiaBrasil.Models;
using EconomiaBrasil.Responses;

namespace EconomiaBrasil.Handlers;

public class GetInformationSelicHandler(IHttpClientFactory httpClientFactory) : IGetInformationSelic
{
    private readonly HttpClient _client = httpClientFactory.CreateClient(Configuration.HttpClientName);
    
    public async Task<Response<ReuniaoModel>> GetLastAta(int numberOfAtas = 1)
    {
        using (var response = await _client.GetAsync(Configuration.ListAtasUrl + numberOfAtas))
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
        var numberOfLastAta = await GetLastAta();
        using (var response = await _client.GetAsync(Configuration.DetailsSelicUrl + numberOfLastAta))
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