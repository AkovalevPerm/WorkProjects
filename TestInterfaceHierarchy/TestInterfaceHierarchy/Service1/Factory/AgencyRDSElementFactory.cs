namespace TestInterfaceHierarchy.Service1.Factory
{
    using System;
    using System.Collections.Generic;
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
