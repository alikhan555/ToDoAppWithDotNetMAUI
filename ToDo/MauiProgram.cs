﻿using Microsoft.Extensions.Logging;
using ToDo.DAL;
using ToDo.ViewModel;

namespace ToDo;

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

		builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<MainPageViewModel>();

        builder.Services.AddTransient<DetailPage>();
        builder.Services.AddTransient<DetailPageViewModel>();

		builder.Services.AddSingleton<TaskToDoRepository>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
