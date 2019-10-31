using System;
using System.Collections.Generic;

namespace TestInterfaceHierarchy.Factory
{
    using ContentClass;
    using Interface;

    public class AgencyRDSElementFactory : IAgencyContentFactory<RDSElement>
    {
        public IEnumerable<RDSElement> GetSpContent()
        {
            throw new NotImplementedException();
        }
    }
}
