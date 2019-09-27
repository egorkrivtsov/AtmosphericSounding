using System.Windows.Controls;
using WpfUI.Common;
using WpfUI.Views.Common;

namespace WpfUI.Views.Controls
{
    public class UserControlGeneric<TModel> : UserControl, IEditableControl where TModel : ValidatableModel, ICloneableGeneric<TModel>, new()
    {
        private readonly TModel modelBackup;

        public TModel ViewModel
        {
            get => DataContext as TModel;
            set => DataContext = value;
        }

        public UserControlGeneric() : this(new TModel())
        {
        }

        public UserControlGeneric(TModel model)
        {
            this.DataContext = ViewModel = model;
            modelBackup = model.Clone();
        }

        public void CancelEdit()
        {
            ViewModel = modelBackup;
        }

        public virtual bool Validate()
        {
            return ViewModel.ValidateModel();
        }
    }
}
