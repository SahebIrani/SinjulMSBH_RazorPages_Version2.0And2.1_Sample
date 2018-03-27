﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SinjulMSBH_RazorPages_Webinar.Data;

namespace SinjulMSBH_RazorPages_Webinar.SinjulMSBH2.Customers
{
	public class Create2DotModel: PageModel
	{
		private readonly AppDbContext _db;

		public Create2DotModel ( AppDbContext db )
		{
			_db = db;
		}

		[BindProperty]
		public Customer Customer { get; set; }

		public async Task<IActionResult> OnPostAsync ( )
		{
			if ( !ModelState.IsValid )
			{
				return Page( );
			}

			_db.Customers.Add( Customer );
			await _db.SaveChangesAsync( );
			return RedirectToPage( "../Index" );
		}
	}
}