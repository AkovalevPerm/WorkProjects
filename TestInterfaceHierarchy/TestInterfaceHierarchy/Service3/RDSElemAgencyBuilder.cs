using System;
using System.Collections.Generic;

namespace TestInterfaceHierarchy.Service3
{
    using Service1.ContentClass;

    public class RDSElemAgencyBuilder : IContentBuilder<RDSElement, PremissionAgency>
    {
        public RDSElement BuildContent(int dictID, IEnumerable<PremissionAgency> premissions)
        {
            throw new NotImplementedException();
        }
    }
}
