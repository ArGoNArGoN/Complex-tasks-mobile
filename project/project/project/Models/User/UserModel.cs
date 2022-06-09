using project.Services.Entitys;
using project.Services.UserService;
using System;

namespace project.Models.User
{
    public class UserModel
        : BaseModel
    {
        private ISaveUserService _saveService;

        public UserModel(ISaveUserService saveService)
            : base()
        {
            _saveService = saveService ?? throw new System.ArgumentNullException(nameof(saveService));
        }

        public void SaveModel()
        {
            _saveService?.SaveUser(this);
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LogIn { get; set; }
		public string Role { get; set; }
		public string Image { get; set; }

        public UserEntity CastToEntity()
        {
            return new UserEntity()
            {
                Identity = this.Id,
                FirstName = this.FirstName,
                FullName = this.FullName,
                Image = this.Image,
                LogIn = this.LogIn,
                TitleRole = this.Role
            };
        }
    }
}
