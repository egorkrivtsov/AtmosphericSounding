using System.Collections.Generic;
using Common.Interfaces;

namespace Data.Reader.Interfaces
{
    /// <summary>
    /// Describes the mapping from txt lines to the Model
    /// </summary>
    /// <typeparam name="TModel">The Model mapped to</typeparam>
    public interface ITxtLinesMapping<TModel>: IMapping<IEnumerable<string[]>, TModel>
    {
    }
}
