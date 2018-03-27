using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using SinjulMSBH_RazorPages_Webinar.Services;

namespace SinjulMSBH_RazorPages_Webinar.Extensions
{
	public static class ServiceExtensions
	{
		public static IServiceCollection RegisterCommentService ( this IServiceCollection services )
		{
			return services.AddTransient<ICommentService , CommentService>( );
			//return services
			//	 .AddTransient<ICommentService , CommentService>( )
			//	 .AddTransient<ISecondService , SecondService>( )
			//	 .AddTransient<IThirdService , ThirdService>( )
			//	 .AddTransient<IFourthService , FourthService>( );
		}
	}
}