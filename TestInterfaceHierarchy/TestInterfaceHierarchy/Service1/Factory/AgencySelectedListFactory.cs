using System;
using System.Collections.Generic;

namespace TestInterfaceHierarchy.Factory
{
    using ContentClass;
    using Interface;
    public class AgencySelectedListFactory : IAgencyContentFactory<SelectedList>
    {
        public IEnumerable<SelectedList> GetSpContent()
        {
            throw new NotImplementedException();
        }
    }
}
