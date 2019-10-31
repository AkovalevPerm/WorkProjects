namespace TestInterfaceHierarchy.Service1.Interface
{
    public interface IRegionContentFactory<out TContent> : ISpContentFactory<TContent>
    {

    }
}
