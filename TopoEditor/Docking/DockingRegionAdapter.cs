namespace TopoEditor.Docking
{
    using Microsoft.Practices.ServiceLocation;
    using Prism.Regions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Telerik.Windows.Controls;

    public class DockingRegionAdapter : RegionAdapterBase<RadDocking>
    {
        private IServiceLocator serviceLocator;

        public DockingRegionAdapter(IRegionBehaviorFactory regionBehaviorFactory, IServiceLocator serviceLocator) : base(regionBehaviorFactory)
        {
            this.serviceLocator = serviceLocator;
        }

        protected override void Adapt(IRegion region, RadDocking regionTarget)
        {
            regionTarget.PanesSource = region.Views;
        }

        protected override IRegion CreateRegion()
        {
            var region = new Region();
            region.Behaviors.Add("DockActivationRegionBehavior", serviceLocator.GetInstance<DockActivationRegionBehavior>());
            return region;
        }
    }
}