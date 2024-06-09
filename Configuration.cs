namespace EconomiaBrasil;

public static class Configuration
{
    public const string HttpClientName = "COPOM";
    public const int DefaultStatusCode = 200;
    public static string ListAtasUrl = "https://www.bcb.gov.br/api/servico/sitebcb/copom/atas?quantidade=1";
    public static string DetailsSelicUrl  =
        "https://www.bcb.gov.br/api/servico/sitebcb/copom/comunicados_detalhes?nro_reuniao=";
    
    
}