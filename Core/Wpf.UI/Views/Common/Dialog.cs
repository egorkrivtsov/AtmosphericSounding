using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.DataVisualization;
using RSG;
using WpfUI.Common;
using WpfUI.Views.Controls;

namespace WpfUI.Views.Common
{
    public class Dialog
    {
        public static Promise<TModel> Open<TModel>(UserControlGeneric<TModel> userControl, string title = "") where TModel : ValidatableModel, 
            ICloneableGeneric<TModel>, new()
        {
            return new Promise<TModel>((success,reject) =>
            {
                if (new DialogCommon(userControl, title).ShowDialog() != true)
                    userControl.CancelEdit(); 
                else
                    success(userControl.ViewModel);
            });
        }
    }
}
