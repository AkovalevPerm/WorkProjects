﻿using System;
using System.Collections.Generic;

namespace TestInterfaceHierarchy.Service3
{
    using Service1.ContentClass;

    public class TreeListContentBuilder<TPremission> : IContentBuilder<TreeList, TPremission>
    {
        private readonly IContentBuilder<RDSElement, TPremission> _contentBuilder;

        public TreeListContentBuilder(IContentBuilder<RDSElement, TPremission> contentBuilder)
        {
            _contentBuilder = contentBuilder;
        }

        public TreeList BuildContent(int dictID, IEnumerable<TPremission> premission)
        {
            var RDSelements = _contentBuilder.BuildContent(dictID, premission);
            //return GetTreeListFromRDSElements(RDSelements)
            throw new NotImplementedException();
        }
    }
}
