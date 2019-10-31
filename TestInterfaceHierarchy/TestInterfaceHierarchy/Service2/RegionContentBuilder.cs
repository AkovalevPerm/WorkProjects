using System;
using TestInterfaceHierarchy.ContentClass;

namespace TestInterfaceHierarchy.Service
{
    public class RegionContentBuilder : CommonContentBuilder
    {
        public override RDSElement GetRDSElementContent()
        {
            throw new NotImplementedException();
        }

        public override SelectedList GetSelectedListContent()
        {
            throw new NotImplementedException();
        }

        public override TreeList GetTreeListContent()
        {
            throw new NotImplementedException();
        }
    }
}
