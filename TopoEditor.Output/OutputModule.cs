namespace TopoEditor.Output
{
    using Microsoft.Practices.Unity;
    using Prism.Modularity;
    using Prism.Regions;
    using TopoEditor.Infrastructure;
    using TopoEditor.Output.Services;
    using TopoEditor.Output.Views;

    public class OutputModule : IModule
    {
        private readonly IUnityContainer container;
        private readonly IRegionManager regionManager;

        public OutputModule(IRegionManager regionManager, IUnityContainer container)
        {
            this.regionManager = regionManager;
            this.container = container;
        }

        public void Initialize()
        {
            // this.container.RegisterType<IInstalledPackageViewModel, InstalledPackageViewModel>(new ContainerControlledLifetimeManager());
            this.container.RegisterType<IOutputWindowOptionsService, OutputWindowOptionsService>();

            this.regionManager.RegisterViewWithRegion(RegionNames.DocumentsRegion, typeof(OutputView));
        }
    }
}