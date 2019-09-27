using System.ComponentModel;
using System.Windows.Input;
using WpfUI.Common;
using WpfUI.Views.Common;

namespace WpfUI.ViewModels
{
    public abstract class DockWindow: ValidatableModel//,INotifyPropertyChanged
    {
        private ICommand _CloseCommand;
        public ICommand CloseCommand
        {
            get
            {
                if (_CloseCommand == null)
                    _CloseCommand = new Command(Close);
                //new RelayCommand(call => Close());
                return _CloseCommand;
            }
        }

        public bool IsClosed { get; set; }
        
        public bool CanClose { get; set; }

        public string Title { get; set; }

        public DockWindow()
        {
            this.CanClose = true;
            this.IsClosed = false;
        }

        public void Close()
        {
            this.IsClosed = true;
        }

        //public event PropertyChangedEventHandler PropertyChanged;

    }
}
