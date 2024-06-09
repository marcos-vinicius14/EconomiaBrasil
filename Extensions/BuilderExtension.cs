using EconomiaBrasil.Handlers;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

namespace EconomiaBrasil.Extensions;

public static class BuilderExtension
{
    public static void AddHttpClient(this WebAssemblyHostBuilder builder)
    {
        builder.Services.AddHttpClient("ListATAS", options =>
        {
            options.BaseAddress = new Uri("https://www.bcb.gov.br/api/servico/sitebcb/copom/atas?quantidade=1");
        });
        
        builder.Services.AddHttpClient("DetailsSelic", options =>
        {
            options.BaseAddress = new Uri(Configuration.DetailsSelicUrl);
        });
    }
    public static void AddServices(this WebAssemblyHostBuilder builder)
    {
        builder.Services.AddTransient<IGetInformationSelic, GetInformationSelicHandler>();
    }
    public static void AddMudService(this WebAssemblyHostBuilder builder)
    {
        builder.Services.AddMudServices();
    }
    
}