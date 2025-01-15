using Client11.Services;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;


namespace Client11
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                })
                .UseMauiCommunityToolkit();



            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif
            
            builder.Services.AddSingleton<IAppService,AppService>();
            builder.Services.AddSingleton<IRegistrationService, RegistrationService>();
            builder.Services.AddSingleton<IAppStateService, AppStateService>();
            
            builder.Services.AddSingleton<IProductServices, ProductServices > ();
            builder.Services.AddSingleton<ICategoryDataServices1, CategoryDataServices1>();
            builder.Services.AddSingleton<IMultipleFileUploadServices, MultipleFileUploadServices>();
            builder.Services.AddSingleton<IAdminRegistrationService, AdminRegistrationService>();
            builder.Services.AddSingleton<IUserAuthenticationService, UserAuthenticationService>();
            

            builder.Services.AddSingleton<IUserRoleService, UserRoleService>();
            builder.Services.AddMudServices();

            return builder.Build();
        }
    }
}
