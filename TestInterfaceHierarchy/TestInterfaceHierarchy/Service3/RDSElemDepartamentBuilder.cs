using System;
using System.Collections.Generic;

namespace TestInterfaceHierarchy.Service3
{
    using Service1.ContentClass;

    public class RDSElemDepartamentBuilder : IContentBuilder<RDSElement, PremissionDepartement>
    {
        public RDSElement BuildContent(int dictID, IEnumerable<PremissionDepartement> premissions)
        {
            throw new NotImplementedException();
        }
    }
}
