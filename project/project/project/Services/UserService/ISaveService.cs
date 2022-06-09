using project.Models.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace project.Services.UserService
{
    public interface ISaveUserService
    {
        void SaveUser(UserModel model);
    }
}
