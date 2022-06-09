using project.Exceptions;
using project.Models.User;
using project.Services.ServiceDialog;
using project.Services.UserService;

using System;
using System.Linq;

using Xamarin.Forms;

namespace project.ViewModels
{
	public class AuthorizationViewModel
		: BaseViewModel
	{
		private readonly IAuthorizationService _service = DependencyService.Get<IAuthorizationService>();
		private readonly IServiceDialog _serviceDialog = DependencyService.Get<IServiceDialog>();

		public AuthorizationUserModel UserModel { get; set; }
		public Command<String> AuthorizationCommand { get; }

		public AuthorizationViewModel()
		{
			if (_service.IsAuthorized())
			{
				Application.Current.MainPage = new MainPage();
			}
			else
			{
				UserModel = new AuthorizationUserModel();
			}

			AuthorizationCommand = new Command<String>(Authorization);
		}

		private async void Authorization(String password)
		{
			try
			{
				UserModel.Password = password;

				var user = await _service.Authorization(UserModel);

				Application.Current.MainPage = new MainPage();
			}
			catch (HttpClientException ex)
			{
				UserModel.Password = null;
				await _serviceDialog.ShowDialogAsync("Ошибка авторизации!", ex.ErrorPropertys.Any() ? ex.ErrorPropertys
					.Select(x => x.Value.Aggregate((x1, y1) => x1 + Environment.NewLine + y1))
					?.Aggregate((x1, y1) => x1 + Environment.NewLine + Environment.NewLine + y1) : "Неправильный логин или пароль!",
					"Ок");
			}
			catch (Exception ex)
			{
				UserModel.Password = null;
				await _serviceDialog.ShowDialogAsync("Ошибка авторизации!", ex.Message, "Ок");
			}
		}
	}
}
