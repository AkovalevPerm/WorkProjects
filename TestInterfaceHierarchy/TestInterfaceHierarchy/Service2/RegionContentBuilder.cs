namespace TestInterfaceHierarchy.Service2
{
    using System;
    using Service1.ContentClass;

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
