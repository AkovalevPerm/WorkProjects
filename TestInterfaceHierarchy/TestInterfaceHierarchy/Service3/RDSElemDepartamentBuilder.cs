using System;
using System.Collections.Generic;
using TestInterfaceHierarchy.ContentClass;

namespace TestInterfaceHierarchy.Service3
{
    public class RDSElemDepartamentBuilder : IContentBuilder<RDSElement, PremissionDepartement>
    {
        public RDSElement BuildContent(int dictID, IEnumerable<PremissionDepartement> premissions)
        {
            throw new NotImplementedException();
        }
    }
}
