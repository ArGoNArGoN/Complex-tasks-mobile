using System;

namespace project.Models.User
{
    /// <summary>
    /// И тут я решил, что клинет должен быть тонким.
    /// Валидация не нужна!
    /// </summary>
    public class AuthorizationUserModel
        : BaseModel
    {
        private string logIn;
        private string password;

        public String LogIn 
        {
            get => logIn;
            set 
            { 
                logIn = value;
                OnPropertyChanged(nameof(LogIn));
            } 
        }
        public String Password 
        {
            get => password;
            set 
            {
                password = value;
                OnPropertyChanged(nameof(LogIn));
            }
        }
    }
}
