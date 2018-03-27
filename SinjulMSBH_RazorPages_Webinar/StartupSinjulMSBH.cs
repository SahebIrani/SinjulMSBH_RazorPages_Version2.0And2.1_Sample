using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SinjulMSBH_RazorPages_Webinar.Data;
using SinjulMSBH_RazorPages_Webinar.Services;

namespace SinjulMSBH_RazorPages_Webinar
{
	public class StartupSinjulMSBH
	{
		public StartupSinjulMSBH ( IHostingEnvironment env )
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
				    options.RootDirectory = "/SinjulMSBH";
				    //options.Conventions.AddPageRoute( );
				    //options.Conventions.AuthorizeFolder( "/Account/Manage" );
				    //options.Conventions.AuthorizePage( "/Account/Logout" );
				    //options.Conventions.AllowAnonymousToPage( "/Private/PublicPage" );
				    //options.Conventions.AllowAnonymousToFolder( "/Private/PublicPages" );
			    } );
			//.WithRazorPagesAtContentRoot( );
			//.WithRazorPagesRoot( "/path/to/razor/pages" );
		}

		public void Configure ( IApplicationBuilder app )
		{
			if ( HostingEnvironment.IsDevelopment( ) )
			{
				app.UseDeveloperExceptionPage( );
			}
			else
			{
				app.UseExceptionHandler( "/error" );
			}

			app.UseStaticFiles( );

			app.UseMvc( );
		}
	}
}