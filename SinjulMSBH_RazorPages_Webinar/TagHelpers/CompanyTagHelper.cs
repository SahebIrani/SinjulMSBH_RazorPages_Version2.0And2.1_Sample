using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace SinjulMSBH_RazorPages_Webinar.TagHelpers
{
	public class Organisation
	{
		public string Name { get; set; }
		public string StreetAddress { get; set; }
		public string AddressLocality { get; set; }
		public string AddressRegion { get; set; }
		public string PostalCode { get; set; }
	}

	public class CompanyTagHelper: TagHelper
	{
		public Organisation Organisation { get; set; }

		public override void Process ( TagHelperContext context , TagHelperOutput output )
		{
			output.TagName = "div";
			output.Attributes.Add( "itemscope itemtype" , "http://schema.org/Organization" );

			output.Content.SetHtmlContent(
			    $@"<span itemprop=""name"">{Organisation.Name}</span>
		    <address itemprop=""address"" itemscope itemtype=""http://schema.org/PostalAddress"">
		    <span itemprop=""streetAddress"">{Organisation.StreetAddress}</span><br>
		    <span itemprop=""addressLocality"">{Organisation.AddressLocality}</span><br>
		    <span itemprop=""addressRegion"">{Organisation.AddressRegion}</span><br>
		    <span itemprop=""postalCode"">{Organisation.PostalCode}</span>" );
		}
	}
}