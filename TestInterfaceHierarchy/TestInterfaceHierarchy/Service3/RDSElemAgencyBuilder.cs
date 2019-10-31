using System;
using System.Collections.Generic;
using TestInterfaceHierarchy.ContentClass;

namespace TestInterfaceHierarchy.Service3
{
    public class RDSElemAgencyBuilder : IContentBuilder<RDSElement, PremissionAgency>
    {
        public RDSElement BuildContent(int dictID, IEnumerable<PremissionAgency> premissions)
        {
            throw new NotImplementedException();
        }
    }
}
