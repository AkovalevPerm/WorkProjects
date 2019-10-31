namespace TestInterfaceHierarchy.Interface
{
    public interface IRegionContentFactory<out TContent> : ISpContentFactory<TContent>
    {

    }
}
