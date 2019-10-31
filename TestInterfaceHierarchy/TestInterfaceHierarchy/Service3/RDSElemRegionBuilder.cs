using System;
using System.Collections.Generic;
using TestInterfaceHierarchy.ContentClass;

namespace TestInterfaceHierarchy.Service3
{
    public class RDSElemRegionBuilder : IContentBuilder<RDSElement, PremissionRegion>
    {
        public RDSElement BuildContent(int dictID, IEnumerable<PremissionRegion> premissions)
        {
            throw new NotImplementedException();
        }
    }
}
