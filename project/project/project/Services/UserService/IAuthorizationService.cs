using project.Models.User;

using System;
using System.Threading.Tasks;

namespace project.Services.UserService
{
    public interface IAuthorizationService
	{
		Task<UserModel> Authorization(AuthorizationUserModel authorizationModel);
		Boolean IsAuthorized();
	}
}
