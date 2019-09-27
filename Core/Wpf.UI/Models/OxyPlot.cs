using System.Collections.ObjectModel;
using System.Collections.Specialized;
using OxyPlot;
using OxyPlot.Series;
using NotifyCollectionChangedAction = System.Collections.Specialized.NotifyCollectionChangedAction;

namespace WpfUI.Models
{
    public class OxyPlotModel : PlotModel
    {
        public OxyPlotModel()
        {
            SeriesItems = new ObservableCollection<LineSeries>();
            SeriesItems.CollectionChanged += SeriesItems_CollectionChanged;
        }

        private void SeriesItems_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
                foreach (var newItem in e.NewItems)
                    Series.Add(newItem as Series);
            else if (e.Action == NotifyCollectionChangedAction.Reset)
                Series.Clear();
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                for (int i = e.OldStartingIndex; i < e.OldStartingIndex + e.OldItems.Count; i++)
                {
                    Series.RemoveAt(i);
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Replace)
            {
                int i = e.OldStartingIndex;
                foreach (var newItem in e.NewItems)
                { 
                    Series[i] = newItem as Series;
                    i++;
                }
            }
        }

        public ObservableCollection<LineSeries> SeriesItems { get; set; }

    }
}
