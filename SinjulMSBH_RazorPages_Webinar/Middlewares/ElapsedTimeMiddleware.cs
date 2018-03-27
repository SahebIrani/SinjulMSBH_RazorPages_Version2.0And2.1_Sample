using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace SinjulMSBH_RazorPages_Webinar.Middlewares
{
	public class ElapsedTimeMiddleware
	{
		private readonly ILogger _logger;
		private readonly RequestDelegate _next;

		public ElapsedTimeMiddleware ( RequestDelegate next , ILogger<ElapsedTimeMiddleware> logger )
		{
			_next = next;
			_logger = logger;
		}

		public async Task Invoke ( HttpContext context )
		{
			var sw = new Stopwatch();
			sw.Start( );

			await _next( context );

			var isHtml = context.Response.ContentType?.ToLower().Contains("text/html");
			if ( context.Response.StatusCode == 200 && isHtml.GetValueOrDefault( ) )
			{
				_logger.LogInformation( $"{context.Request.Path} executed in {sw.ElapsedMilliseconds}ms" );
			}
		}
	}

	public static class BuilderExtensions
	{
		public static IApplicationBuilder UseElapsedTimeMiddleware ( this IApplicationBuilder app )
		{
			return app.UseMiddleware<ElapsedTimeMiddleware>( );
		}
	}
}