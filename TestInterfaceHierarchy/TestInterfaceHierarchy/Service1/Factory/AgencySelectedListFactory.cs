namespace TestInterfaceHierarchy.Service1.Factory
{
    using System;
    using System.Collections.Generic;
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
