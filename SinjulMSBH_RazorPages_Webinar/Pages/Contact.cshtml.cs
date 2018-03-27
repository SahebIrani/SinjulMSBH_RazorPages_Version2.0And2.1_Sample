using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SinjulMSBH_RazorPages_Webinar.Services;
using SinjulMSBH_RazorPages_Webinar.TagHelpers;

namespace SinjulMSBH_RazorPages_Webinar.Pages
{
	public class ContactModel: PageModel
	{
		private readonly ICommentService _commentService;

		public ContactModel ( ICommentService commentService )
		{
			_commentService = commentService;
		}

		public Organisation Company { get; set; }

		public void OnGet ( )
		{
			Message = "Contact Details";
			Company = new Organisation
			{
				Name = "Microsoft Corp" ,
				StreetAddress = "One Microsoft Way" ,
				AddressLocality = "Redmond" ,
				AddressRegion = "WA" ,
				PostalCode = "98052-6399"
			};
		}

		[BindProperty] public string From { get; set; }
		[BindProperty] public string Email { get; set; }
		[BindProperty] public string Subject { get; set; }
		[BindProperty] public string Comments { get; set; }

		public string Message { get; set; }

		//public void OnGet ( )
		//{
		//	Message = "Your contact page.";
		//}

		public async Task<IActionResult> OnPost ( )
		{
			using ( var smtp = new SmtpClient( ) )
			{
				var credential = new NetworkCredential
				{
					UserName = "user@outlook.com",  // replace with valid value
					Password = "password"  // replace with valid value
				};
				smtp.Credentials = credential;
				smtp.Host = "smtp-mail.outlook.com";
				smtp.Port = 587;
				smtp.EnableSsl = true;
				var message = new MailMessage
				{
					Body = $"From: {From} at {Email}<p>{Comments}</p>",
					Subject = Subject,
					IsBodyHtml = true
				};
				message.To.Add( "contact@domain.com" );
				await smtp.SendMailAsync( message );
				return RedirectToPage( "Thanks" );
			}
		}

		//Single Responsibility Principal and DRY
		//Inversion of Control Containers
		//services.AddTransient<ICommentService , CommentService>();

		public async Task<IActionResult> OnPost2 ( )
		{
			var service = new CommentService();
			await service.Send( From , Subject , Email , Comments );
			return RedirectToPage( "Thanks" );
		}

		//Dependency Inversion Principal

		public async Task<IActionResult> OnPost3 ( )
		{
			await _commentService.Send( From , Subject , Email , Comments );
			return RedirectToPage( "Thanks" );
		}
	}
}