namespace WpfUI.Views.Controls
{
    public interface IEditableControl
    {
        bool Validate();

        void CancelEdit();
    }
}