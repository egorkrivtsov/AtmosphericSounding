using System.ComponentModel;
using System.Windows;
using WpfUI.ViewModels;
using WpfUI.Views.Controls;

namespace WpfUI.Views
{
    /// <summary>
    /// Interaction logic for DialogCommon.xaml
    /// </summary>
    public partial class DialogCommon : Window
    {
        public DialogCommon()
        {
            InitializeComponent();
        }


        public DialogCommon(IEditableControl content, string title)
        {
            DataContext = content;
            Title = title;
            InitializeComponent();
        }

        private void SaveClose(object sender, RoutedEventArgs e)
        {
            if (DataContext is IEditableControl validator && !validator.Validate())
                return;

            DialogResult = true;
            Close();
        }
    }

}
