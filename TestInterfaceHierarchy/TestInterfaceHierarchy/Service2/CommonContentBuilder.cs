using System;
using TestInterfaceHierarchy.ContentClass;

namespace TestInterfaceHierarchy.Service
{
    public abstract class CommonContentBuilder : IContentBuilderService
    {
        public abstract RDSElement GetRDSElementContent();

        public abstract SelectedList GetSelectedListContent();

        public abstract TreeList GetTreeListContent();
    }
}
