using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using WpfUI.Annotations;

namespace WpfUI.Views.Common
{
    public abstract class ValidatableModel : IDataErrorInfo, INotifyPropertyChanged
    {
        protected bool ValidationEnabled;

        public string this[string columnName]
        {
            get
            {
                if (ValidationEnabled)
                {
                    var errors = Validate(columnName);
                    if (errors.ContainsKey(columnName))
                        return errors[columnName];
                }

                 return null;
            }
        }

        public string Error => String.Empty;//throw new NotImplementedException();

        public bool ValidateModel()
        {
            ValidationEnabled = true;

            var errors = Validate();

            var isPrimaryModelValid = !errors.Any();
            var isNestedModelsValid = ValidateNestedModels();

            if (!isPrimaryModelValid)
                foreach (var property in errors.Keys)
                    OnPropertyChanged(property);

            return isPrimaryModelValid && isNestedModelsValid;
        }

        protected virtual bool ValidateNestedModels()
        {
            return true;
        }

        protected virtual Dictionary<string,string> Validate(string propertyName = null)
        {
            return new Dictionary<string, string>();
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
