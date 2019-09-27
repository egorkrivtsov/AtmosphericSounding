using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace WpfUI.ViewModels
{
    public class DockManager
    {
        /// <summary>Gets a collection of all visible documents</summary>
        public ObservableCollection<DockWindow> Documents { get; private set; }

        public ObservableCollection<object> Anchorables { get; private set; }

        public DockManager()
        {
            this.Documents = new ObservableCollection<DockWindow>();
            this.Anchorables = new ObservableCollection<object>();
        }

        public DockManager(IEnumerable<DockWindow> dockWindowViewModels):this()
        {
            foreach (var document in dockWindowViewModels)
            {
                //document.PropertyChanged += DockWindowViewModel_PropertyChanged;
                if (!document.IsClosed)
                    this.Documents.Add(document);
            }
        }

        private void DockWindowViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            DockWindow document = sender as DockWindow;

            if (e.PropertyName == nameof(DockWindow.IsClosed))
            {
                if (!document.IsClosed)
                    this.Documents.Add(document);
                else
                    this.Documents.Remove(document);
            }
        }
    }
}
