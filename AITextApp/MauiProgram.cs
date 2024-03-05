using AITextApp.Services;
using AITextApp.Services.Interfaces;
using Microsoft.Extensions.Logging;
using AITextApp.Events;
using AITextApp.ViewModels;
using SharpHook;
using TextCopy;

namespace AITextApp
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services
                .GetClipboard()
                .AddSingleton<IPromptService, PromptService>()
                .AddSingleton<IEventAggregator, EventAggregator>()
                .AddSingleton<IEventSimulator, EventSimulator>()
                .AddSingleton<IUserActivitySimulator, SharpUserActivitySimulator>()
                .AddSingleton<ITextProcessingService, TextProcessingService>()
                .AddSingleton<ShortcutViewModel>()
                .AddSingleton<ApiKeyViewModel>()
                .AddSingleton<PromptViewModel>()
                .AddSingleton<MainPageViewModel>()
                .AddSingleton<MainPage>();


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }


        private static IServiceCollection GetClipboard(this IServiceCollection services)
        {
            services.InjectClipboard();
            return services;
        }
    }
}
