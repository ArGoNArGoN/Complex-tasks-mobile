using project.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace project.ViewModels
{
	public interface IActionToDo
	{
		String TitleAction { get; }
		Boolean ItsPossibleCommit { get; }
		Boolean ItsPossibleRollback { get; }

		BaseViewModel Commit();
		BaseViewModel Rollback();
	}
}
