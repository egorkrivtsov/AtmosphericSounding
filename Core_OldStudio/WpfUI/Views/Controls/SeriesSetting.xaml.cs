using System.Windows;

namespace WpfUI.Views.Controls
{
    /// <summary>
    /// Interaction logic for SeriesSetting.xaml
    /// </summary>
    public partial class SeriesSetting : UserControlGeneric<ViewModels.SeriesSetting>
    {
        public SeriesSetting()
        {
            InitializeComponent();
        }

        public SeriesSetting(ViewModels.SeriesSetting seriesSetting) : base(seriesSetting)
        {
            InitializeComponent();
        }

    }
}
