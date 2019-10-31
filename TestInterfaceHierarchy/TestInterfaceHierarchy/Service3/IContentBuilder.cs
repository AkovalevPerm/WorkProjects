using System.Collections.Generic;

namespace TestInterfaceHierarchy.Service3
{
    public interface IContentBuilder<TRes, TPremission>
    {
        TRes BuildContent(int dictID, IEnumerable<TPremission> premissions);
    }
}
