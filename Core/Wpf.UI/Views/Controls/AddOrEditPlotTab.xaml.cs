namespace WpfUI.Views.Controls
{
    public partial class AddOrEditPlotTab : UserControlGeneric<ViewModels.PlotDockWindow>
    {
        public AddOrEditPlotTab():base()
        {
            InitializeComponent();
        }

        public AddOrEditPlotTab(ViewModels.PlotDockWindow plotTab):base(plotTab)
        {
            InitializeComponent();
        }
    }
}
