using System;
using System.Collections.Generic;

namespace TestInterfaceHierarchy.Factory
{
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
