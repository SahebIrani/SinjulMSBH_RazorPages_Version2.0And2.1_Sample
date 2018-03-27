using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace SinjulMSBH_RazorPages_Webinar
{
	public class Program
	{
		public static void Main ( string[ ] args )
		{
			BuildWebHost( args ).Run( );
		}

		public static IWebHost BuildWebHost ( string[ ] args ) =>
		    WebHost.CreateDefaultBuilder( args )
		    //.UseStartup( "SinjulMSBH_RazorPages_Webinar" )
		    .UseStartup<StartupSinjulMSBH2>( )
#if SinjulMSBH
		    //.UseStartup<StartupSinjulMSBH>( )
#elif SinjulMSBH2
		    //.UseStartup<StartupSinjulMSBH2>( )
#elif SinjulMSBH3
		    //.UseStartup<StartupSinjulMSBH3>( )
#else
		    //.UseStartup<Startup>( )

#endif
		    .Build( );
	}
}