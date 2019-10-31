namespace TestInterfaceHierarchy.Interface
{
    public interface IAgencyContentFactory<out TContent> : ISpContentFactory<TContent>
    {

    }
}
