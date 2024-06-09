using System.Text.RegularExpressions;
using EconomiaBrasil.Handlers;
using EconomiaBrasil.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Web;

namespace EconomiaBrasil.Pages;

public partial class HomePage : ComponentBase
{
    #region Properties
    public ComunicadoModel Comunicado { get; set; } = new();

    #endregion

    #region Services

    [Inject] public IGetInformationSelic InfoSelicService { get; set; } = null!;

    [Inject] public NavigationManager NavigationManager { get; set; } = null!;

    [Inject] public ISnackbar Snackbar { get; set; } = null!;

    #endregion

    #region Methods

    protected override async Task OnInitializedAsync()
    {
        var comunicados = await InfoSelicService.GetLatestAnnouncement();
        if (comunicados.Any())
        {
            Snackbar.Add("Não foi possível encontrar reuniões.", Severity.Error);
        }
        foreach (var comunicado in comunicados)
        {
            Comunicado.nro_reuniao = comunicado.nro_reuniao;
            Comunicado.Titulo = comunicado.Titulo;
            Comunicado.TextoComunicado = HttpUtility.HtmlDecode(Regex.Replace(comunicado.TextoComunicado, "<.*?>", String.Empty)) ;
            Comunicado.DataReferencia = comunicado.DataReferencia;
        }
        
    }

    #endregion
}