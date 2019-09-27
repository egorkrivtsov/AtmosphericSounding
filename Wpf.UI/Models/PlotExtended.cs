using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Wpf;
using WpfUI.Common;
using WpfUI.ViewModels;

namespace WpfUI.Models
{
    public class PlotExtended : Plot, INotifyPropertyChanged
    {
        public PlotExtended()
        {
        }

        

        public PlotExtended(PlotSettings plotSettings, IData data)
        {
            Data = data;
            PlotSettings = plotSettings;
            PlotSettings.PropertyChanged += PlotSettings_PropertyChanged;

            Title = PlotSettings.Title;
            AddLineSeries(plotSettings.Series, Data.Source);
        }

        private void PlotSettings_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (PlotSettings == null)
                return;

            if (e.PropertyName == nameof(PlotSettings.Title))
                this.Title = PlotSettings.Title;
        }

        public void AddLineSeries(IEnumerable<SeriesSetting> series, IEnumerable data)
        {
            foreach (var seriesSetting in series)
                AddLineSeries(seriesSetting, data);
        }

        public IData Data { get; set; }

        public PlotSettings PlotSettings { get; set; }

        public ObservableCollection<DataGridColumn> Columns { get; set; } = new ObservableCollection<DataGridColumn>();

        public void AddLineSeries(SeriesSetting series, IEnumerable data)
        {

            if (Axes.Count == 0)
                AddLineAxises();


            CheckColumn(series.DataX);
            CheckColumn(series.DataY);

            Series.Add(new LineSeries
            {
                DataFieldX = series.DataX.PropertyFullName,
                DataFieldY = series.DataY.PropertyFullName,
                ItemsSource = data,
                Title = series.LegendTitle,
                Color = series.LineColor,
                MarkerFill = series.MarkerColor

            });
            
        }

        public void AddLineAxises()
        {
            
            Axes.Add(new OxyPlot.Wpf.LinearAxis
            {
                Position = AxisPosition.Bottom,
                MajorGridlineStyle = LineStyle.Dash
            });

            Axes.Add(new OxyPlot.Wpf.LinearAxis
            {
                Position = AxisPosition.Left,
                MajorGridlineStyle = LineStyle.Dash
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void CheckColumn(PropertyMetaData property)
        {
            if (property == null)
                return;

            var dgTextColumns = Columns.Select(c => c as DataGridTextColumn).Where(c=>c!=null).ToList();
            if (!dgTextColumns.Any(c => c.SortMemberPath == property.PropertyFullName))
            {
                Columns.Add(new DataGridTextColumn
                {
                    Header = property.DisplayName,
                    Binding = new Binding(property.PropertyFullName)
                });
            }
        }
    }
}
