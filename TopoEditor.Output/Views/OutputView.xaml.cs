using System;
using System.Collections.Generic;
using System.Linq;

namespace TopoEditor.Output.Views
{
    using System;

    using System.Windows.Controls;
    using Telerik.Windows.Controls;
    using Telerik.Windows.Controls.Docking;
    using TopoEditor.Infrastructure.Interfaces;
    using PRISMIActiveAware = Prism.IActiveAware;

    /// <summary>
    /// Interaction logic for OutputView.xaml
    /// </summary>

    public partial class OutputView : RadPane, IPaneModel, PRISMIActiveAware
    {
        public OutputView() => InitializeComponent();

        public event EventHandler IsActiveChanged;

        public DockState Position
        {
            get
            {
                return DockState.DockedBottom;
            }
        }

        protected override void OnIsActiveChanged()
        {
            base.OnIsActiveChanged();
            this.OnIsActiveChanged(EventArgs.Empty);
        }

        private void OnIsActiveChanged(EventArgs e)
        {
            if (this.IsActiveChanged != null)
            {
                this.IsActiveChanged(this, e);
            }
        }
    }
}