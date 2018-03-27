using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SinjulMSBH_RazorPages_Webinar
{
	public class AppSettings
	{
		public string First { get; set; }
		public string Second { get; set; }
		public Car Car { get; set; }
	}

	public class Car
	{
		public int NumberOfDoors { get; set; }
		public DateTime RegistrationDate { get; set; }
		public string Color { get; set; }
	}
}