using EconomiaBrasil.Handlers;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

namespace EconomiaBrasil.Extensions;

public static class BuilderExtension
{
    public static void AddServices(this WebAssemblyHostBuilder builder)
    {
        builder.Services.AddTransient<IGetInformationSelic, GetInformationSelicHandler>();
    }

    public static void AddMudService(this WebAssemblyHostBuilder builder)
    {
        builder.Services.AddMudServices();
    }
}