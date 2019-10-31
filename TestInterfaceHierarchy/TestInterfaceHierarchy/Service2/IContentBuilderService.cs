namespace TestInterfaceHierarchy.Service2
{
    using Service1.ContentClass;

    interface IContentBuilderService
    {
        RDSElement GetRDSElementContent();
        TreeList GetTreeListContent();
        SelectedList GetSelectedListContent();
    }
}
