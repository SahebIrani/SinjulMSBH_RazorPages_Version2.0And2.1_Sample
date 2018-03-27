using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;

namespace SinjulMSBH_RazorPages_Webinar.SinjulMSBH3
{
	[RequireHttps]
	public class BasePageModel: PageModel
	{
	}

	[IgnoreAntiforgeryToken( Order = 1001 )]
	[ValidateAntiForgeryToken( Order = 1000 )]
	public class IndexModel: BasePageModel
	{
		private readonly IConfiguration _configuration;

		public IndexModel ( IConfiguration configuration )
		{
			_configuration = configuration;
		}

		public void OnPost1 ( )
		{
			var emailAddress = Request.Form["emailaddress"];
			// do something with emailAddress
		}

		public void OnPost11 ( )
		{
			var emailAddress = Request.Form["emailaddress"];
			// do something with emailAddress
		}

		[BindProperty]
		public string EmailAddress { get; set; }

		public void OnPost111 ( )
		{
			// do something with EmailAddress
		}

		[BindProperty]
		[Required]
		[MinLength( 6 )]
		public string UserName { get; set; }

		[BindProperty]
		[Required, MinLength( 6 )]
		public string Password { get; set; }

		[BindProperty, Required, Compare( nameof( Password ) )]
		public string Password2 { get; set; }

		[Compare( nameof( Password ) , ErrorMessage = "Make sure both passwords are the same" )]
		public string Password3 { get; set; }

		//public IActionResult OnPost222 ( )
		//{
		//	if ( ModelState.IsValid )
		//	{
		//		// do something
		//		return RedirectToPage( "Contact" ));
		//	}
		//	else
		//	{
		//		return Page( );
		//	}
		//}

		public void OnGetConf ( )
		{
			ViewData[ "config" ] = _configuration[ "AppSettings:First" ];
			var settings = _configuration.GetSection("AppSettings").Get<AppSettings>();
			ViewData[ "RegistrationDate" ] = settings.Car.RegistrationDate;
		}

		[BindProperty]
		public string Name { get; set; }

		[BindProperty]
		public Member Member2 { get; set; }

		//public int Number { get; set; }

		public int Number { get; set; } = 2;

		public List<SelectListItem> Items =>
			 Enumerable.Range( 1 , 3 ).Select( x => new SelectListItem
			 {
				 Value = x.ToString( ) ,
				 Text = x.ToString( )
			 } ).ToList( );

		public class Member
		{
			public int PersonId { get; set; }
			public string Name { get; set; }

			[EmailAddress]
			[Display( Name = "Email Address" )]
			public string Email { get; set; }

			[DataType( DataType.Password )]
			public string Password { get; set; }

			[DataType( DataType.PhoneNumber )]
			public string Telephone { get; set; }

			[Display( Name = "Date of Birth" )]
			public DateTime DateOfBirth { get; set; }

			public decimal Salary { get; set; }

			[Url]
			public string Website { get; set; }

			[Display( Name = "Send spam to me" )]
			public bool SendSpam { get; set; }

			public int? NumberOfCats { get; set; }
		}

		public IActionResult OnGet ( )
		{
			return new RedirectToPageResult( "Index" );
		}

		public RedirectToPageResult OnGet2 ( )
		{
			return new RedirectToPageResult( "Index" );
		}

		public IActionResult OnPost ( )
		{
			if ( !ModelState.IsValid )
			{
				return new PageResult( );
			}

			// otherwise do some processing
			return new RedirectToPageResult( "Index" );
		}

		public IActionResult OnPost2 ( )
		{
			if ( !ModelState.IsValid )
			{
				return Page( );
			}
			// otherwise do some processing
			return RedirectToPage( "Index" );
		}

		//ChallengeResult => Challenge 401
		//ContentResult	=> Content 200
		//EmptyResult => 200
		//FileContentResult => File 200
		//FileStreamResult => 200
		//ForbidResult => Forbid 403

		//LocalRedirectResult =>
		//LocalRedirect	302
		//LocalRedirectPermanent	301
		//LocalRedirectPreserveMethod	307
		//LocalRedirectPreserveMethodPermanent  308

		//NotFoundResult    NotFound	404
		//PageResult  Page	200
		//PhysicalFileResult      PagePhysicalFile  200
		//RedirectResult => 302 301 307 308

		//RedirectToPageResult =>
		//RedirectToPage	301
		//RedirectToPagePermanent	302
		//RedirectToPagePreserveMethod	307
		//RedirectToPagePreserveMethodPermanent	308

		//SignInResult
		//SignOutResult
		//StatusCodeResult
		//UnauthorizedResult		401
	}
}