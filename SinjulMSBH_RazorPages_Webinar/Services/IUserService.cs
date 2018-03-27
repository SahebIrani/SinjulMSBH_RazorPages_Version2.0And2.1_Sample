using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RazorPages;
using SinjulMSBH_RazorPages_Webinar.Services;

namespace SinjulMSBH_RazorPages_Webinar.Services
{
	public interface IUserService
	{
		Task<List<User>> GetUsersAsync ( );

		Task<User> GetUserAsync ( int id );
	}

	public class UserService: IUserService
	{
		public async Task<List<User>> GetUsersAsync ( )
		{
			using ( var client = new HttpClient( ) )
			{
				var endPoint = "https://jsonplaceholder.typicode.com/users";
				var json = await client.GetStringAsync(endPoint);
				return JsonConvert.DeserializeObject<List<User>>( json );
			}
		}

		public async Task<User> GetUserAsync ( int id )
		{
			using ( var client = new HttpClient( ) )
			{
				var endPoint = $"https://jsonplaceholder.typicode.com/users/{id}";
				var json = await client.GetStringAsync(endPoint);
				return JsonConvert.DeserializeObject<User>( json );
			}
		}
	}
}