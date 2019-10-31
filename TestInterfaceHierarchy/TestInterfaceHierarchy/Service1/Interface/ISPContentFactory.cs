using System.Collections.Generic;

namespace TestInterfaceHierarchy.Interface
{
    public interface ISpContentFactory<out TContent>
    {
        IEnumerable<TContent> GetSpContent();
    }
}