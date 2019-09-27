using System;
using WpfUI.Common;
using WpfUI.Views.Common;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace WpfUI.ViewModels
{
    public class PlotSettings : ValidatableModel, ICloneableGeneric<PlotSettings>
    {
        public string TabTitle { get; set; }

        public string Title { get; set; }

        public IEnumerable<PropertyMetaData> Data { get; set; }

        public ObservableCollection<SeriesSetting> Series { get; set; }

        public PlotSettings()
        {

        }

        public PlotSettings(IEnumerable<PropertyMetaData> data)
        {
            Data = data;
            Series = new ObservableCollection<SeriesSetting> { new SeriesSetting { IsDefault = true } };
        }

        public static PlotSettings CreateInstance<TModel>()
        {
            return new PlotSettings(MetaData.FromCache<TModel>(item => !String.IsNullOrWhiteSpace(item.DisplayName)));
        }

        public PlotSettings Clone()
        {
            return new PlotSettings(Data);
        }

        public Command AddSeries => new Command(() =>
        {
            Series.Add(new SeriesSetting());
        });

        public Command<SeriesSetting> RemoveSeries => new Command<SeriesSetting>(item =>
        {
            Series.Remove(item);
        });

        public Command<SeriesSetting> Configure => new Command<SeriesSetting>(item =>
        {
            Dialog
                .Open(new Views.Controls.SeriesSetting(item))
                .Then(vm => { Series[Series.IndexOf(item)] = vm; }); 
        });


        protected override bool ValidateNestedModels()
        {
            bool isValid = true;
            foreach (var seriesSetting in Series)
                isValid &= seriesSetting.ValidateModel();
            return isValid;
        }

        protected override Dictionary<string, string> Validate(string propertyName = null)
        {
            var errors = new Dictionary<string, string>();
            if (propertyName == nameof(TabTitle) || String.IsNullOrWhiteSpace(propertyName))
            {
                if (String.IsNullOrWhiteSpace(TabTitle))
                    errors.Add(nameof(TabTitle),"Обязательное поле");
            }

            return errors;
        }
    }
}
