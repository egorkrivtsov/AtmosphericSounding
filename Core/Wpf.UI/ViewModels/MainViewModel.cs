using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Windows;
using WpfUI.Common;
using WpfUI.Models;
using WpfUI.Views.Common;
using WpfUI.Views.Controls;

namespace WpfUI.ViewModels
{
    /// <summary>
    /// Main MVVM model
    /// </summary>
    public class MainViewModel: INotifyPropertyChanged
    {
        /// <summary>
        /// Is needed for INotifyPropertyChanged
        /// Property "OnChange" will be raised by Fody(see nugets packages)
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
            TabManager = new DockManager();
            MetaData.InitCache<RawData>();
            Data = new Marl();
        }

        public IData Data { get; set; }

        public DockManager TabManager { get; set; }

        

        public Command AddPlot => new Command(() =>
        {
            //Dialog
            //    .Open(new AddOrEditPlot(PlotSettings.CreateInstance<RawData>()), "Добавить график")
            //    .Then(plotSettings =>
            //    {
            //        TabManager.Documents.Add(new PlotDockWindow
            //        {
            //            Title = plotSettings.TabTitle,
            //            Plot = new PlotExtended(plotSettings, Data)
            //        });
            //    });
            Dialog
                .Open(new AddOrEditPlotTab(new PlotDockWindow(Data)), "Добавить график")
                .Then(plotSettings =>
                {
                    var x = 1;
                });
        });

        public Command RemovePlot => new Command(() =>
        {

        });

        #region Init data

        public Command RefreshData => new Command(() =>
        {
            try
            {
                HttpClient client = new HttpClient { BaseAddress = new Uri("http://localhost:7468/api/") };
                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));


                var commonPath = $@"..\..\..\Tests\Data\marl.example";
                string gsPath = $"{commonPath}.info";
                string tuPath = $@"{commonPath}.tu";
                string crdPath = $@"{commonPath}.crd";


                byte[] result = GetBytesFromFile(gsPath);
                byte[] result1 = GetBytesFromFile(tuPath);
                byte[] result2 = GetBytesFromFile(crdPath);

                using (var formData = new MultipartFormDataContent())
                {
                    formData.Add(new ByteArrayContent(result), "info", "file1");
                    formData.Add(new ByteArrayContent(result1), "tu", "file1");
                    formData.Add(new ByteArrayContent(result2), "crd", "file1");

                    HttpResponseMessage response = client.PostAsync("file", formData).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        try
                        {
                            var data = response.Content.ReadAsAsync<List<RawData>>().Result.OrderBy(d => d.Id).ToList();
                            //Data = new Marl();
                            foreach (var item in data)
                                Data.Source.Add(item);

                            
                        }
                        catch (Exception exception)
                        {
                            MessageBox.Show(exception.ToString());
                        }
                    }
                    else
                        MessageBox.Show($"Error Code {response.StatusCode} : Message - {response.ReasonPhrase}");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        });

        

        private byte[] GetBytesFromFile(string filePath)
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                return Encoding.ASCII.GetBytes(sr.ReadToEnd());
            }
        }

        #endregion

    }
}
