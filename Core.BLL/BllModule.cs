﻿using Core.BLL.Interfaces;
using Core.BLL.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Core.BLL
{
	public static class BllModule
	{
		public static IServiceCollection AddServices(this IServiceCollection services)
		{
			services.AddTransient<IUserService, UserService>();
			services.AddTransient<IAdventureService, AdventureService>();
			services.AddTransient<IExperienceService, ExperienceService>();
			services.AddTransient<ILocationService, LocationService>();

			return services;
		}
	}
}
