using System.Collections.Generic;
using Common.Interfaces;

namespace Data.Reader.Interfaces
{

    public interface ITxtLinesMapping<TModel>: IMapping<IEnumerable<string[]>, TModel>
    {
    }
}
