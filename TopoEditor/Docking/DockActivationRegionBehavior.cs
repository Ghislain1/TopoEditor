namespace TopoEditor.Docking
{
    using Prism;
    using Prism.Regions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DockActivationRegionBehavior : RegionBehavior
    {
        private IRegionViewRegistry regionViewRegistry;

        public DockActivationRegionBehavior(IRegionViewRegistry regionViewRegistry)
        {
            this.regionViewRegistry = regionViewRegistry;
        }

        public void OnViewIsActiveChanged(object sender, EventArgs e)
        {
            var activeAware = (IActiveAware)sender;
            if (activeAware.IsActive)
            {
                this.Region.Activate(sender);
            }
            else
            {
                this.Region.Deactivate(sender);
            }
        }

        public void OnViewRegistered(object sender, ViewRegisteredEventArgs e)
        {
            var view = e.GetView() as IActiveAware;
            if (view != null)
            {
                // NOTE: This could cause memory leaks! Consider using weak event managers or remove
                //       handler when removing the view.
                view.IsActiveChanged += this.OnViewIsActiveChanged;
            }
        }

        protected override void OnAttach()
        {
            if (this.regionViewRegistry != null)
            {
                this.regionViewRegistry.ContentRegistered += this.OnViewRegistered;
            }
        }
    }
}