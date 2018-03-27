using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SinjulMSBH_RazorPages_Webinar.Services
{
	public interface ICommentService
	{
		Task Send ( string from , string subject , string email , string comments );
	}

	public class CommentService: ICommentService
	{
		public async Task Send ( string from , string subject , string email , string comments )
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
					Body = $"From: {from} at {email}<p>{comments}</p>",
					Subject = subject,
					IsBodyHtml = true
				};
				message.To.Add( "contact@domain.com" );
				await smtp.SendMailAsync( message );
			}
		}
	}
}