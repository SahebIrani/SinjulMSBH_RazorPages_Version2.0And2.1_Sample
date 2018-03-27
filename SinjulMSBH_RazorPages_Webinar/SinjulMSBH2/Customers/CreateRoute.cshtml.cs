using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SinjulMSBH_RazorPages_Webinar.Data;

namespace SinjulMSBH_RazorPages_Webinar.SinjulMSBH2.Customers
{
	public class CreateRouteModel: PageModel
	{
		private readonly AppDbContext _db;

		public CreateRouteModel ( AppDbContext db )
		{
			_db = db;
		}

		[BindProperty]
		public Customer Customer { get; set; }

		//public async Task<IActionResult> OnGetAsync ( string handler )
		//{
		//	return Content( handler );
		//}

		public async Task<IActionResult> OnPostJoinListAsync ( )
		{
			if ( !ModelState.IsValid )
			{
				return Page( );
			}

			_db.Customers.Add( Customer );
			await _db.SaveChangesAsync( );
			return RedirectToPage( "/Index" );
		}

		public async Task<IActionResult> OnPostJoinListUCAsync ( )
		{
			if ( !ModelState.IsValid )
			{
				return Page( );
			}
			Customer.Name = Customer.Name?.ToUpper( );
			return await OnPostJoinListAsync( );
		}
	}
}