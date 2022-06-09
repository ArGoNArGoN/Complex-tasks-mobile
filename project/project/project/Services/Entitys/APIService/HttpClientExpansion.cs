using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using project.Exceptions;

using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Essentials;

namespace project.Services.Entitys.APIService
{
	public static class HttpClientExpansion
	{
		private const String baseURL = "http://192.168.0.101:8200/api/"; 
		private static String cookie = "";

		public static HttpClient GetHttpClient(this ISupportHttpClient http)
		{
			var client = new HttpClient();
			client.DefaultRequestHeaders.Add("Accept", "application/json");

			if (!String.IsNullOrEmpty(HttpClientExpansion.cookie))
				client.DefaultRequestHeaders.Add("Cookie", HttpClientExpansion.cookie);
			
			return client;
		}
		public static JsonSerializerSettings GetJSONSerializeSettings(this ISupportHttpClient http)
			=> new JsonSerializerSettings() { ContractResolver = new CamelCasePropertyNamesContractResolver() };
		public static StringContent GetStringContent<T>(this ISupportHttpClient http, T model, String mediaType = "application/json")
		{
			var content = JsonConvert.SerializeObject(model);

			return new StringContent(content, Encoding.UTF8, mediaType);
		}
		public static String GetBaseURL(this ISupportHttpClient http) => baseURL;

		public static Boolean IsOpenConnection(this ISupportHttpClient http)
		{
			var profiles = Connectivity.ConnectionProfiles;
			return profiles.Any(x => x == ConnectionProfile.Ethernet || x == ConnectionProfile.WiFi);
		}

		public static void ResponseValidate(this ISupportHttpClient http, HttpResponseMessage response)
		{
			if (response is null)
				throw new ArgumentNullException(nameof(response));

			switch (response.StatusCode)
			{
				case HttpStatusCode.OK:
					return;
				case HttpStatusCode.MethodNotAllowed:
					throw new HttpClientException($"Пользователь не авторизован!");
				case HttpStatusCode.GatewayTimeout:
				case HttpStatusCode.BadGateway:
					throw new Exception($"Проблема с сервром. Обратись к Администратору: {response}");
				case HttpStatusCode.RequestTimeout:
					throw new Exception($"Проблема с приложением! Срочно обратись к Администратору: {response}");
				case HttpStatusCode.NotFound:
					throw new Exception($"Не найдна конечная точка: {response}");
				default:
					throw new Exception($"Ошибка запроса:  {response}");
			}
		}
		public static void SetCookie(this ISupportHttpClient http, String cookie)
        {
			HttpClientExpansion.cookie = cookie;
		}

		public static async Task<T> ResponseValidate<T>(this ISupportHttpClient http, HttpResponseMessage response)
		{
			if (response is null)
				throw new ArgumentNullException(nameof(response));

			switch (response.StatusCode)
			{
				case HttpStatusCode.OK:
					return await response.Content.ReadAsAsync<T>();
				case HttpStatusCode.MethodNotAllowed:
					throw new HttpClientException($"Пользователь не авторизован!");
				case HttpStatusCode.GatewayTimeout:
				case HttpStatusCode.BadGateway:
					throw new Exception($"Проблема с сервром. Обратись к Администратору: {response}");
				case HttpStatusCode.RequestTimeout:
					throw new Exception($"Проблема с приложением! Срочно обратись к Администратору: {response}");
				case HttpStatusCode.NotFound:
					throw new Exception($"Не найдна конечная точка: {response}");
				default:
					throw new Exception($"Ошибка запроса:  {response}");
			}
		}
	}
}
