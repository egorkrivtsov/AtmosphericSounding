using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using WpfUI.Common;

namespace WpfUI.Models
{
    public interface IData
    {
        IEnumerable<PropertyMetaData> Properties { get; set; }

        IList Source { get; set; }

        IEnumerable<DataGridColumn> Columns { get; set; }
    }

    public class Marl:IData
    {
        public Marl()
        {
            Properties = MetaData.FromCache<RawData>();
            Source = new ObservableCollection<RawData>();
            Columns = new ObservableCollection<DataGridColumn>(Properties
                .Where(p => !String.IsNullOrEmpty(p.DisplayName))
                .Select(p => new DataGridTextColumn
                {
                    Header = p.DisplayName,
                    Binding = new Binding(p.PropertyFullName)
                }));
        }

        public IEnumerable<PropertyMetaData> Properties { get; set; }
        public IList Source { get; set; }
        public IEnumerable<DataGridColumn> Columns { get; set; }
    }
}
