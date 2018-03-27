using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SinjulMSBH_RazorPages_Core2_1.Pages.SinjulMSBH
{
	[BindProperty]
	public class IndexModel: PageModel
	{
		[Required]
		public string Filter { get; set; }

		public InputModel Input { get; set; }

		public class InputModel
		{
			public int Id { get; set; }
			public string FileName { get; set; }
		}

		public override void OnPageHandlerExecuted ( PageHandlerExecutedContext context )
		{
			//Do this thing before ..
			base.OnPageHandlerExecuted( context );
		}

		public override Task OnPageHandlerExecutionAsync ( PageHandlerExecutingContext context , PageHandlerExecutionDelegate next )
		{
			return base.OnPageHandlerExecutionAsync( context , next );
		}

		public override void OnPageHandlerSelected ( PageHandlerSelectedContext context )
		{
			base.OnPageHandlerSelected( context );
		}

		public override Task OnPageHandlerSelectionAsync ( PageHandlerSelectedContext context )
		{
			return base.OnPageHandlerSelectionAsync( context );
		}

		public void OnGet ( )
		{
		}

		public void OnPost ( )
		{
		}

		public void OnPostFoo ( )
		{
		}

		public void OnPostBar ( )
		{
		}
	}
}