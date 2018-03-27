using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using SinjulMSBH_RazorPages_Webinar.Data;
using SinjulMSBH_RazorPages_Webinar.Middlewares;
using SinjulMSBH_RazorPages_Webinar.Services;

namespace SinjulMSBH_RazorPages_Webinar
{
	public class StartupSinjulMSBH3
	{
		public StartupSinjulMSBH3 ( IHostingEnvironment env )
		{
			HostingEnvironment = env;
		}

		public IHostingEnvironment HostingEnvironment { get; }

		public void ConfigureServices ( IServiceCollection services )
		{
			services.AddDbContext<AppDbContext>( options =>
					options.UseInMemoryDatabase( "SinjulMSBHInMemoryDb" ) );

			services.AddMvc( )
			 .AddRazorPagesOptions( options =>
			    {
				    options.RootDirectory = "/SinjulMSBH3";
				    options.Conventions.ConfigureFilter( new IgnoreAntiforgeryTokenAttribute( ) );
				    //options.Conventions.AddPageRoute( "Archive/Post" , "Post/{year}/{month}/{day}/{title}" );
				    //options.Conventions.AddPageRoute( "index" , "{*url}" );
				    //options.Conventions.AddPageRoute( );
				    //options.Conventions.AuthorizeFolder( "/Account/Manage" );
				    //options.Conventions.AuthorizePage( "/Account/Logout" );
				    //options.Conventions.AllowAnonymousToPage( "/Private/PublicPage" );
				    //options.Conventions.AllowAnonymousToFolder( "/Private/PublicPages" );
			    } );
			//.WithRazorPagesAtContentRoot( );
			//.WithRazorPagesRoot( "/path/to/razor/pages" );

			services.Configure<RouteOptions>( options =>
			{
				options.LowercaseUrls = true;
				options.AppendTrailingSlash = true;
			} );
			services.Configure<MvcOptions>( options =>
			{
				options.Filters.Add( new RequireHttpsAttribute( ) );
				options.Filters.Add( new RequireHttpsAttribute { Permanent = true } );
			} );

			services.AddTransient<IUserService , UserService>( );
		}

		public void Configure ( IApplicationBuilder app )
		{
			if ( HostingEnvironment.IsDevelopment( ) )
			{
				app.UseDeveloperExceptionPage( );
				app.UseDatabaseErrorPage( );
				app.UseStatusCodePages( );
				app.UseStatusCodePages( "text/html" , "<h1>Error! Status Code {0}</h1>" );
				app.UseStatusCodePagesWithRedirects( "/errors/{0}" );
			}
			else
			{
				app.UseExceptionHandler( "/Error" );

				var options = new RewriteOptions().AddRedirectToHttpsPermanent();
				app.UseRewriter( options );

				var options2 = new RewriteOptions().AddRedirectToHttps();
				app.UseRewriter( options2 );
			}

			app.UseStaticFiles( );

			app.UseElapsedTimeMiddleware( );

			app.UseMvc( );

			//app.Run( async ( context ) =>
			//{
			//	await context.Response.WriteAsync( "All done" );
			//} );
		}
	}
}