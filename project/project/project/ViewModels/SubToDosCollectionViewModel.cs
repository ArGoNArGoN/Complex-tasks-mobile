using project.Models.ToDo;
using System.Collections.ObjectModel;
using System.Linq;

namespace project.ViewModels
{
    /// <summary>
    /// для отображения спсика всех подзадач
    /// </summary>
    public class SubToDosCollectionViewModel
    {
        public ObservableCollection<BaseSubToDoViewModel> CollectionViewModels { get; }

        public SubToDosCollectionViewModel(ObservableCollection<SubModel> collection)
        {
            CollectionViewModels = new ObservableCollection<BaseSubToDoViewModel>(collection.Select(x => new BaseSubToDoViewModel(x)));
        }
    }
}