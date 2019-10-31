using System;
using System.Collections.Generic;

namespace TestInterfaceHierarchy.Service3
{
    using Service1.ContentClass;

    public class SelectListContentBuilder<TPremission> : IContentBuilder<SelectedList, TPremission>
    {
        private readonly IContentBuilder<RDSElement, TPremission> _contentBuilder;

        public SelectListContentBuilder(IContentBuilder<RDSElement, TPremission> contentBuilder)
        {
            _contentBuilder = contentBuilder;
        }

        public SelectedList BuildContent(int dictID, IEnumerable<TPremission> premission)
        {
            var RDSelements = _contentBuilder.BuildContent(dictID, premission);
            //return GetSelectListFromRDSElements(RDSelements)
            throw new NotImplementedException();
        }
    }
}
