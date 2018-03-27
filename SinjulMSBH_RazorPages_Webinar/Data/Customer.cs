using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SinjulMSBH_RazorPages_Webinar.Data
{
	public class Customer
	{
		public int Id { get; set; }

		[Required, StringLength( 100 )]
		public string Name { get; set; }
	}
}