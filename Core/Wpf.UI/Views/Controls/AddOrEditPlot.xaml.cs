namespace WpfUI.Views.Controls
{
    public partial class AddOrEditPlot : UserControlGeneric<ViewModels.PlotSettings>
    {
        public AddOrEditPlot():base()
        {
            InitializeComponent();
        }

        public AddOrEditPlot(ViewModels.PlotSettings plotSettings):base(plotSettings)
        {
            InitializeComponent();
        }
    }
}
