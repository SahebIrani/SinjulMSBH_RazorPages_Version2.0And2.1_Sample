using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SinjulMSBH_RazorPages_Webinar.Data
{
	public class AppDbContext: DbContext
	{
		public AppDbContext ( DbContextOptions options )
		    : base( options )
		{
		}

		public DbSet<Customer> Customers { get; set; }
	}
}