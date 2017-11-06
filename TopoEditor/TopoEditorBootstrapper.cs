namespace TopoEditor
{
    using Microsoft.Practices.Unity;
    using Prism.Modularity;
    using Prism.Regions;
    using Prism.Unity;
    using System.Windows;
    using Telerik.Windows.Controls;
    using TopoEditor.Docking;
    using Views;

    public class TopoEditorBootstrapper : UnityBootstrapper
    {
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            //this.Container.RegisterType<IChocolateyService, ChocolateyService>(new ContainerControlledLifetimeManager());

            //this.Container.RegisterType<IMessenger, Messenger>(new ContainerControlledLifetimeManager());
            //this.Container.RegisterType<IConfigurationService, ConfigurationService>(new ContainerControlledLifetimeManager());
            //this.Container.RegisterType<IDialogService, DialogService>(new ContainerControlledLifetimeManager());
            //this.Container.RegisterType<IInstallService, InstallService>(new ContainerControlledLifetimeManager());

            //this.Container.RegisterType<IPackageService, PackageService>(new ContainerControlledLifetimeManager());
            //this.Container.RegisterType<IPowerShellService, PowerShellService>(new ContainerControlledLifetimeManager());
        }

        protected override RegionAdapterMappings ConfigureRegionAdapterMappings()
        {
            // Registering the DockingRegionAdapter. This will allow the dock to be marked as region
            // and accomudate views.
            RegionAdapterMappings mappings = base.ConfigureRegionAdapterMappings();
            var regionBehaviorFactory = Container.Resolve<IRegionBehaviorFactory>();
            mappings.RegisterMapping(typeof(RadDocking), Container.Resolve<DockingRegionAdapter>());
            return mappings;
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new ConfigurationModuleCatalog();
        }

        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }
    }
}