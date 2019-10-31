namespace TestInterfaceHierarchy.Service2
{
    using Service1.ContentClass;

    public abstract class CommonContentBuilder : IContentBuilderService
    {
        public abstract RDSElement GetRDSElementContent();

        public abstract SelectedList GetSelectedListContent();

        public abstract TreeList GetTreeListContent();
    }
}
