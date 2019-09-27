namespace WpfUI.Common
{
    public interface ICloneableGeneric<out TModel> 
    {
        TModel Clone();
    }
    /*
    public TModel Clone()
    {
        using (var ms = new MemoryStream())
        {
            var formatter = new BinaryFormatter();
            formatter.Serialize(ms, this);
            ms.Position = 0;

            return (TModel)formatter.Deserialize(ms);
        }
    }*/
}
