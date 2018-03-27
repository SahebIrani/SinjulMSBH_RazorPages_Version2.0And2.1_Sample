#region snippet_ALL

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using SinjulMSBH_RazorPages_Webinar.Data;

namespace SinjulMSBH_RazorPages_Webinar.SinjulMSBH.Customers
{
	#region snippet_PageModel

	public class CreateModel: PageModel
	{
		private readonly AppDbContext _db;

		public CreateModel ( AppDbContext db )
		{
			_db = db;
		}

		[BindProperty]
		public Customer Customer { get; set; }

		#region snippet_OnPostAsync

		public async Task<IActionResult> OnPostAsync ( )
		{
			if ( !ModelState.IsValid )
			{
				return Page( );
			}

			_db.Customers.Add( Customer );
			await _db.SaveChangesAsync( );
			return RedirectToPage( "/Index" );
		}

		#endregion snippet_OnPostAsync
	}

	#endregion snippet_PageModel
}

#endregion snippet_ALL