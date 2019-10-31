namespace TestInterfaceHierarchy
{
    using System.Collections.Generic;
    using Service1.ContentClass;
    using Service3;

    public class AppController
    {
        private readonly IContentBuilder<TreeList, PremissionAgency> _agencyTreeListBuilder;
        private readonly IContentBuilder<SelectedList, PremissionAgency> _agencySelectedListBuilder;
        private readonly IContentBuilder<SelectedList, PremissionRegion> _regionSelectedListBuilder;

        /*public void Test1()
        {
            IAgencyContentFactory<TreeList> factory = new AgencyTreeListFactory();//Resolve DI
            var treeList = factory.GetSpContent();
        }*/

        public void DIResolve()
        {
            IContentBuilder<TreeList, PremissionAgency> resolveAgencyContTreeListBuilder()
            {
                var mainBuilder = new RDSElemAgencyBuilder();
                var treeListBuilder = new TreeListContentBuilder<PremissionAgency>(mainBuilder);
                return treeListBuilder;
            }

            IContentBuilder<SelectedList, PremissionAgency> resolveAgencyContSelectListBuilder()
            {
                var mainBuilder = new RDSElemAgencyBuilder();
                var selectListBuilder = new SelectListContentBuilder<PremissionAgency>(mainBuilder);
                return selectListBuilder;
            }

            IContentBuilder<SelectedList, PremissionRegion> resolveDepartmentContSelectListBuilder()
            {
                var mainBuilder = new RDSElemRegionBuilder();
                var selectListBuilder = new SelectListContentBuilder<PremissionRegion>(mainBuilder);
                return selectListBuilder;
            }
        }

        public AppController(
            IContentBuilder<TreeList, PremissionAgency> agencyTreeListBuilder,
            IContentBuilder<SelectedList, PremissionAgency> agencySelectedListBuilder,
            IContentBuilder<SelectedList, PremissionRegion> regionSelectedListBuilder)
        {
            _agencyTreeListBuilder = agencyTreeListBuilder;
            _agencySelectedListBuilder = agencySelectedListBuilder;
            _regionSelectedListBuilder = regionSelectedListBuilder;
            int dictAgencyId = 123;
            var treeListAgency = _agencyTreeListBuilder.BuildContent(dictAgencyId, new List<PremissionAgency>());
            var selectListAgency = _agencySelectedListBuilder.BuildContent(dictAgencyId, new List<PremissionAgency>());
            int dictRegionId = 321;
            var selectListRegion = _regionSelectedListBuilder.BuildContent(dictRegionId, new List<PremissionRegion>());

        }
    }
}
