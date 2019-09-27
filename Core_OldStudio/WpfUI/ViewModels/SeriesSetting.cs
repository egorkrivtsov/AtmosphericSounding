using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Media;
using WpfUI.Common;
using WpfUI.Views.Common;
using Color = System.Windows.Media.Color;

namespace WpfUI.ViewModels
{
    [Serializable]
    public class SeriesSetting : ValidatableModel, ICloneableGeneric<SeriesSetting>
    {
        public SeriesSetting()
        {
            IsDefault = false;
            LineColor = Colors.Red;
        }

        private string legendTitle;
        public string LegendTitle {
            get
            {
                if (String.IsNullOrWhiteSpace(legendTitle) && (DataX != null && DataY != null))
                        legendTitle = $"{DataX.DisplayName} / {DataY.DisplayName}";
                return legendTitle;
            }
            set => legendTitle = value;
        }

        public PropertyMetaData DataX { get; set; }

        public PropertyMetaData DataY { get; set; }

        public bool IsDefault { get; set; }

        public Color LineColor { get; set; }

        public Font LegendFont { get; set; }

        public Color MarkerColor { get; set; }

        public SeriesSetting Clone()
        {
            return new SeriesSetting();
        }

        public Command LegendFontOpen => new Command(() =>
        {
            var dialog = new FontDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
                LegendFont = dialog.Font;
        });

        protected override Dictionary<string, string> Validate(string propertyName = null)
        {
            var errors = new Dictionary<string, string>();

            if (DataX == null)
                errors.Add(nameof(DataX), "Обязательное поле");

            if (DataY == null)
                errors.Add(nameof(DataY), "Обязательное поле");
            //if (propertyName == nameof(DataX) || String.IsNullOrWhiteSpace(propertyName))
            //{
                
            //}
            //else if (propertyName == nameof(DataY) || String.IsNullOrWhiteSpace(propertyName))
            //{
                
            //}

            return errors;
        }
    }
}
