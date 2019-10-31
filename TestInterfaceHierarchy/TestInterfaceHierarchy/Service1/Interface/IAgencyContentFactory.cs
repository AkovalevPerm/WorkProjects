namespace TestInterfaceHierarchy.Service1.Interface
{
    public interface IAgencyContentFactory<out TContent> : ISpContentFactory<TContent>
    {

    }
}
