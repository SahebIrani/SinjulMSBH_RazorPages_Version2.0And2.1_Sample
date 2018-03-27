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
using SinjulMSBH_RazorPages_Webinar.Extensions;

namespace SinjulMSBH_RazorPages_Webinar
{
	public class Startup
	{
		public Startup ( IConfiguration configuration )
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices ( IServiceCollection services )
		{
			services.AddDbContext<ApplicationDbContext>( options =>
			     options.UseSqlServer( Configuration.GetConnectionString( "DefaultConnection" ) ) );

			//services.AddIdentity<ApplicationUser , IdentityRole>( )
			//    .AddEntityFrameworkStores<ApplicationDbContext>( )
			//    .AddDefaultTokenProviders( );

			services.AddIdentity<ApplicationUser , IdentityRole>( options =>
			{
				options.Password.RequireDigit = true;
				options.Password.RequireLowercase = true;
				options.Password.RequireUppercase = true;
				options.Password.RequiredLength = 6;
				options.Password.RequireNonAlphanumeric = false;
				options.Password.RequiredUniqueChars = 6;
			} )
			.AddEntityFrameworkStores<ApplicationDbContext>( )
			.AddDefaultTokenProviders( );

			//services.AddMvc( );
			services.AddMvc( )
			   .AddRazorPagesOptions( options =>
			   {
				   options.Conventions.AuthorizeFolder( "/Account/Manage" );
				   options.Conventions.AuthorizePage( "/Account/Logout" );
			   } );

			// Register no-op EmailSender used by account confirmation and password reset during development
			// For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=532713
			services.AddSingleton<IEmailSender , EmailSender>( );

			//Inversion of Control Containers
			services.RegisterCommentService( );

			//Registering a Service with Constructor Parameters
			var connString = Configuration.GetConnectionString("DefaultConnection");
			if ( connString == null )
				throw new ArgumentNullException( "Connection string cannot be null" );
			services.AddSingleton<IConnectionFactory>( s => new SqlConnectionFactory( connString ) );
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure ( IApplicationBuilder app , IHostingEnvironment env )
		{
			if ( env.IsDevelopment( ) )
			{
				app.UseBrowserLink( );
				app.UseDeveloperExceptionPage( );
				app.UseDatabaseErrorPage( );
			}
			else
			{
				app.UseExceptionHandler( "/Error" );
			}

			app.UseStaticFiles( );

			app.UseAuthentication( );

			app.UseMvc( );
		}
	}
}