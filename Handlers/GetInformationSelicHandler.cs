using System.Text.Json;
using EconomiaBrasil.Models;
using EconomiaBrasil.Responses;

namespace EconomiaBrasil.Handlers;

public class GetInformationSelicHandler : IGetInformationSelic
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly JsonSerializerOptions _serializerOptions;

    public GetInformationSelicHandler(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
        _serializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }

    public async Task<List<ReuniaoModel>?> GetLastAta(int numberOfAtas = 1)
    {
        var client = _httpClientFactory.CreateClient("ListATAS");
        using (var response = await client.GetAsync(Configuration.ListAtasUrl))
        {
            //response.Headers.Add("Access-Control-Allow-Origin", new[]{ " * "});
            
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStreamAsync();
                var reuniaoResponses = await JsonSerializer.DeserializeAsync<ReuniaoResponse>(result, _serializerOptions);
                var reunioes = reuniaoResponses?.Conteudo;

                return reunioes;
            }
            else
            {
                return null;
            }
        }
    }

    public async Task<List<ComunicadoModel>> GetLatestAnnouncement()
    {
        var client = _httpClientFactory.CreateClient("DetailsSelic");
        var numberOfLastAta = await GetLastAta();
        var reuniao = 0;

        if (numberOfLastAta is null)
            return null;

        foreach (var numberAta in numberOfLastAta)
        {
            reuniao = numberAta.NroReuniao;
        }

        using (var response = await client.GetAsync(Configuration.DetailsSelicUrl + reuniao))
        {
            //response.Headers.Add("Access-Control-Allow-Origin", new[]{ " * "});
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStreamAsync();
                var lastAnnouncement = await JsonSerializer.DeserializeAsync<ComunicadoResponse>(result, _serializerOptions);
                var comunicados = lastAnnouncement.Conteudo;

                return comunicados
                    ?? [];

            }
            else
            {
                return null;
            }
        }
    }
}