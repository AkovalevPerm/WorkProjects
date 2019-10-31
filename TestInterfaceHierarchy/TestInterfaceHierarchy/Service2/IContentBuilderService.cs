using TestInterfaceHierarchy.ContentClass;

namespace TestInterfaceHierarchy.Service
{
    interface IContentBuilderService
    {
        RDSElement GetRDSElementContent();
        TreeList GetTreeListContent();
        SelectedList GetSelectedListContent();
    }
}
