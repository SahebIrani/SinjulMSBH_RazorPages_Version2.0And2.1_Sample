using System.Text;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace SinjulMSBH_RazorPages_Webinar.TagHelpers
{
	[HtmlTargetElement( "pager" , Attributes = "total-pages, current-page, link-url" )]
	public class PagerTagHelper: TagHelper
	{
		public override void Process ( TagHelperContext context , TagHelperOutput output )
		{
			if (
			    int.TryParse( context.AllAttributes[ "total-pages" ].Value.ToString( ) , out int totalPages ) &&
			    int.TryParse( context.AllAttributes[ "current-page" ].Value.ToString( ) , out int currentPage ) )
			{
				var url = context.AllAttributes["link-url"].Value;
				output.TagName = "div";
				output.PreContent.SetHtmlContent( @"<ul class=""pagination"">" );

				var content = new StringBuilder();
				for ( var i = 1 ; i <= totalPages ; i++ )
				{
					content.AppendLine( $@"<li class=""{( i == currentPage ? "active" : "" )}""><a href=""{url}?page={i}""  title=""Click to go to page {i}"">{ i}</a></li>" );
				}
				output.Content.SetHtmlContent( content.ToString( ) );
				output.PostContent.SetHtmlContent( "</ul>" );
				output.Attributes.Clear( );
			}
		}
	}

	namespace LearnRazorPages.TagHelpers
	{
		[HtmlTargetElement( "pager" , Attributes = "total-pages, current-page, link-url" )]
		public class PagerTagHelper: TagHelper
		{
			public int CurrentPage { get; set; }
			public int TotalPages { get; set; }

			[HtmlAttributeName( "link-url" )]
			public string Url { get; set; }

			public override void Process ( TagHelperContext context , TagHelperOutput output )
			{
				output.TagName = "div";
				output.PreContent.SetHtmlContent( @"<ul class=""pagination"">" );

				var content = new StringBuilder();
				for ( var i = 1 ; i <= TotalPages ; i++ )
				{
					content.AppendLine( $@"<li class=""{( i == CurrentPage ? "active" : "" )}""><a href=""{Url}?page={i}"" title=""Click to go to page {i}"">{i}</a></li>" );
				}
				output.Content.SetHtmlContent( content.ToString( ) );
				output.PostContent.SetHtmlContent( "</ul>" );
				output.Attributes.Clear( );
			}
		}
	}
}