using project.Exceptions;
using project.Models.User;
using project.Services.Entitys;
using project.Services.Entitys.APIService;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

using Xamarin.Forms.Internals;

namespace project.Services.UserService
{
	public class UserModelRepository
		: IAuthorizationService, ISupportHttpClient, ISaveUserService
	{
		private ICRUD<UserEntity> _service;

		public UserModelRepository(ICRUD<UserEntity> service)
		{
			_service = service ?? throw new ArgumentNullException(nameof(service));
		}

		public UserModel GetUser()
		{
			return _service.Read().FirstOrDefault().CastToModel(this);
		}
		public void CreateUser(UserEntity model)
		{
			var user = _service.Read().FirstOrDefault();

			if (!(user is null))
			{
				model.Identity = user.Identity;

				model.Password = model.Password ?? user.Password;
				model.LogIn = model.Password ?? user.LogIn;

				_service.Update(model);
			}
			else
			{
				_service.Create(model);
			}
		}

		private const String login = "\"LogIn\":";
		private const String password = "\"Password\":";

		public async Task<UserModel> Authorization(AuthorizationUserModel authorizationModel)
		{
			if (!this.IsOpenConnection())
			{
				throw new WebException("Нет соединения!");
			}

			using (var client = this.GetHttpClient())
			{
				var url = $"http://192.168.0.101:8200/api/Authorization";
				
				var response = await client.PostAsync(url, this.GetStringContent(authorizationModel));

				if (response.IsSuccessStatusCode)
				{
					var user = await response.Content
						.ReadAsAsync<UserEntity>();

					var cookie = response.Headers.GetValues("Set-Cookie").First();

					this.SetCookie(cookie);

					user.LogIn = authorizationModel.LogIn;
					user.Password = authorizationModel.Password;

					this.CreateUser(user);

					return user.CastToModel(this);
				}
				else if (response.StatusCode == HttpStatusCode.BadRequest)
				{
					var exception = new HttpClientException();

					var conetent = await response.Content.ReadAsStringAsync();

					if (conetent.Contains(login))
					{
						var index = conetent.IndexOf(login);
						var loginErrorMessage = conetent.Substring(index + login.Length + 2, conetent.IndexOf(']', index) - (index + login.Length + 3));
						exception.ErrorPropertys.Add("LogIn", GetError(loginErrorMessage));
					}

					if (conetent.Contains(password))
					{
						var index = conetent.IndexOf(password);
						var passwordErrorMessage = conetent.Substring(index + password.Length + 2, conetent.IndexOf(']', index) - (index + password.Length + 3));
						exception.ErrorPropertys.Add("Pasword", GetError(passwordErrorMessage));
					}

					throw exception;
				}
				else
				{
					Log.Warning("INFO",await response.Content.ReadAsStringAsync());
					throw new WebException();
				}
			}
		}

		private IEnumerable<String> GetError(String message)
		{
			return message.Split(',').Select(x => x.Trim());
		}

		public Boolean IsAuthorized()
		{
			var user = _service.Read().FirstOrDefault();

			if (user is null)
				return false;

			try
			{
				/// если соединение открыто, мы можем войти, 
				/// TODO: Спросить
				if (this.IsOpenConnection())
				{
					using (var client = this.GetHttpClient())
					{
						var url = $"{this.GetBaseURL()}Authorization";

						var response = client.PostAsync(url, this.GetStringContent(new AuthorizationUserModel() { LogIn = user.LogIn, Password = user.Password })).Result;

						if (response.IsSuccessStatusCode)
						{
							this.SetCookie(response.Headers.GetValues("Set-Cookie").First());
						}

						return response.IsSuccessStatusCode;
					}
				}
				
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public void SaveUser(UserModel model) => CreateUser(model.CastToEntity());
	}
}
