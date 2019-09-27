using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using WpfUI.Common;
using WpfUI.ViewModels;

namespace WpfUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            this.DataContext = new MainViewModel();
            InitializeComponent();
        }

        private void PreviewMouseLeftButtonDown1(object sender, MouseButtonEventArgs e)
        {
            if (!(sender is DataGridColumnHeader columnHeader) ||
                (!Keyboard.IsKeyDown(Key.LeftShift) && !Keyboard.IsKeyDown(Key.RightShift)))
                return;

            foreach (var item in RawDataGrid.Items)
            {
                if (!RawDataGrid.SelectedCells.Contains(new DataGridCellInfo(item, columnHeader.Column)))
                    RawDataGrid.SelectedCells.Add(new DataGridCellInfo(item, columnHeader.Column));
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            CacheWrapper.Dispose();
        }
    }
}
