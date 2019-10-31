namespace TestInterfaceHierarchy.Service1.Interface
{
    using System.Collections.Generic;

    public interface ISpContentFactory<out TContent>
    {
        IEnumerable<TContent> GetSpContent();
    }
}