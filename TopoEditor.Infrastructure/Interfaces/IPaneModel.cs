namespace TopoEditor.Infrastructure.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Telerik.Windows.Controls.Docking;

    public interface IEditorOperationsFactoryService
    {
    }

    public interface ILogEditorProvider
    {
    }

    public interface IMenuService
    {
    }

    public interface IPaneModel
    {
        DockState Position { get; }
    }

    public interface IPickSaveFilename
    {
        string GetFilename(string v1, string v2, string tEXTFILES_FILTER);
    }
}