using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using OxyPlot;
using OxyPlot.Series;
using WpfUI.Common;
using WpfUI.Models;


namespace WpfUI.ViewModels
{
    /// <summary>
    /// Represents Dock Tab/Window for Plot
    /// </summary>
    public class PlotDockWindow : DockWindow,  ICloneableGeneric<PlotDockWindow>
    {
        public PlotDockWindow()
        {
        }

        public PlotDockWindow(IData data)
        {
            Data = data;
            PlotModel = new OxyPlotModel();
            PlotModel.SeriesItems.Add(new LineSeries{ ItemsSource = Data.Source });
        }

        public IData Data { get; set; }

        public OxyPlotModel PlotModel { get; set; }

        
        public Command Edit => new Command(() =>
            {
                
            });

        public Command AddSeries => new Command(() =>
        {
            PlotModel.SeriesItems.Add(new LineSeries { ItemsSource = Data.Source });
        });

        public Command<LineSeries> Configure => new Command<LineSeries>(item =>
        {

        });

        public Command<LineSeries> Remove => new Command<LineSeries>(item =>
        {
            PlotModel.SeriesItems.Remove(item);
        });

        public PlotDockWindow Clone()
        {
            return new PlotDockWindow();
        }
    }
}
