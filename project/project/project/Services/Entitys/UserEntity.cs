using project.Models.User;
using project.Services.UserService;
using SQLite;
using System;

namespace project.Services.Entitys
{
	[Table("User")]
	public class UserEntity
	{
		[PrimaryKey]
		[AutoIncrement]
		public int Identity { get; set; }

		public string FullName { get; set; }
		public string FirstName { get; set; }
		public string TitleRole { get; set; }
		public string LogIn { get; set; }
		public string Password { get; set; }
		public string Image { get; set; }

		public UserModel CastToModel(ISaveUserService saveService)
		{
			return new UserModel(saveService)
			{
				FirstName = this.FirstName,
				FullName = this.FullName,
				Role = this.TitleRole,
				Id = this.Identity,
				Image = this.Image,
				LogIn = this.LogIn
			};
		}
	}
}
