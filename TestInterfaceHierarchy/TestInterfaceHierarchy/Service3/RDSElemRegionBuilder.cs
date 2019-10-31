using System;
using System.Collections.Generic;

namespace TestInterfaceHierarchy.Service3
{
    using Service1.ContentClass;

    public class RDSElemRegionBuilder : IContentBuilder<RDSElement, PremissionRegion>
    {
        public RDSElement BuildContent(int dictID, IEnumerable<PremissionRegion> premissions)
        {
            throw new NotImplementedException();
        }
    }
}
