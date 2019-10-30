using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestInterfaceHierarchy
{
    using ContentClass;
    using Factory;
    using Interface;

    public class Main
    {
        public void Test()
        {
            IAgencyContentFactory<TreeList> factory = new AgencyTreeListFactory();//Resolve DI
            var treeList = factory.GetSpContent();
        }
    }
}
