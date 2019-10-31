namespace TestInterfaceHierarchy.Service1.Factory
{
    using System;
    using System.Collections.Generic;
    using ContentClass;
    using Interface;

    public class AgencyTreeListFactory : IAgencyContentFactory<TreeList>
    {
        public IEnumerable<TreeList> GetSpContent()
        {
            throw new NotImplementedException();
        }
    }
}
